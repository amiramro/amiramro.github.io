
Option Compare Binary

Imports System.IO
Imports System.Globalization

Public Class Form1
    Dim COMBINED_LIST As String = "D:\Nofim\INFO\N_LIST.txt"
    Const COMBINED_LIST_FROM_AMIRAM As String = "\\D:\Nofim\INFO\N_LIST.txt"
    Dim mouseX, mouseY As Integer
    Dim MailList As String
    Dim drag As Boolean
    Dim HEBREW_input As InputLanguage
    Dim lvwColumnSorter As ListViewColumnSorter
    Dim searching As Boolean
    Dim N_LIST As String = My.Resources.N_LIST

    ' SPECIAL CHARACTERS USED:
    ' ChrW(9993) (=Envelope) in column1 denotes mail address added to mail list.
    ' ChrW(183) is part of the line coming from N_LIST. It is used, when LV1 Is sorted by name, 
    '  to protect e.g., "רונן אילנה"  and "רונן עמירם" from being separated by "רונן נעמי" 

    Sub LoadLV1()
        LV1.BeginUpdate()
        LV1.Items.Clear()
        Dim list, line As String
        list = N_LIST
        Do While InStr(list, vbCrLf)
            Dim pos1 As Integer, apartment, name, phone, mail, mobile As String

            'If posZ = 0 Then Exit Do
            line = list.Substring(0, InStr(list, "*"))
            list = list.Substring(line.Length + 2)
            If searching Then
                If Not line.Contains(TBName.Text) Then Continue Do
            End If

            'get apartment
            pos1 = InStr(line, vbTab)
            apartment = line.Substring(0, pos1)
            If apartment <> "" Then line = line.Replace(apartment, "")

            'get name
            pos1 = InStr(line, vbTab)
            name = line.Substring(0, pos1)
            If name.Length < 8 Then Continue Do
            line = line.Replace(name, "")
            If apartment = "" Then  'this is not a tenant; send it down the sorted list
                name = "תת_" & name
            End If

            ' get line phone
            pos1 = InStr(line, vbTab)
            phone = line.Substring(0, pos1)
            line = line.Replace(phone, "")

            'get e-mail
            pos1 = InStr(line, vbTab)
            mail = line.Substring(0, pos1)
            If mail <> "" Then line = line.Replace(mail, "")

            ' get mobile number
            pos1 = InStr(line, "*")
            mobile = line.Substring(0, pos1 - 1)

            ' get new line
            pos1 = InStr(list, "*")
            list = list.Substring(pos1 + 2)

            Dim x As New ListViewItem
            x.SubItems.Add("")
            x.SubItems.Add(phone.Replace(vbTab, ""))
            x.SubItems.Add(name.Replace(vbTab, ""))
            x.SubItems.Add(apartment.PadLeft(4, " ").Replace(vbTab, "").Replace("0000", ""))
            x.SubItems.Add(mobile.Replace(vbTab, ""))
            x.SubItems.Add(mail.Replace(vbTab, ""))
            LV1.Items.Add(x)

        Loop
        LV1.Show()
        LV1.EndUpdate()
    End Sub

    Sub TBName_TextChanged(sender As Object, e As EventArgs) Handles TBName.TextChanged
        For Each ch As String In TBName.Text
            'accept only letters, space, hyphen
            Dim k As Integer = AscW(ch)
            If k < 1487 Or k > 1515 Then
                If k <> 45 And k <> 32 Then
                    TBName.Clear()
                    searching = False
                End If
            Else
                searching = True
                LoadLV1()
            End If
        Next
    End Sub

    Sub DeSelect()
        For Each itm In LV1.Items
            itm.Selected = False
        Next
        LV1.HideSelection = True
    End Sub

    Sub LV1_MouseUp(sender As Object, e As MouseEventArgs) Handles LV1.MouseUp
        Static MobileIndex As Integer
        Dim info As ListViewHitTestInfo = LV1.HitTest(e.X, e.Y), mailitem As String
        Dim columnindex As Integer = info.Item.SubItems.IndexOf(info.SubItem)
        Dim itm As ListViewItem = LV1.Items(info.Item.Index)

        Clear_Mobile()

        Select Case columnindex
            Case 1 ' add mail address to mail list
                If itm.SubItems(6).Text.Contains("@") Then  'subitem(6) contains an e-mail address
                    If itm.SubItems(1).Text = "" Then
                        itm.SubItems(1).Text = ChrW(9993)
                    ElseIf itm.SubItems(1).Text = ChrW(9993) Then
                        itm.SubItems(1).Text = ""
                    End If

                    Update_MailList()
                    DeSelect()
                    TBName.Select()
                End If

            Case 2  ' show mobile number
                If info.Item.Index = MobileIndex Then
                    Clear_Mobile()
                    MobileIndex = Nothing
                    sink.Select()
                    Exit Sub
                End If
                If itm.SubItems(5).Text <> "" Then
                    With LabelMobile
                        If .Text = "" Then
                            .Text = itm.SubItems(5).Text
                            .BackColor = Color.PapayaWhip
                            .Show()
                            MobileIndex = info.Item.Index
                        End If
                    End With
                    itm.BackColor = Color.PapayaWhip
                    sink.Select()
                End If

            Case Else
                sink.Select()
                Exit Sub
        End Select
    End Sub

    Sub Clear_Mobile()
        For Each item In LV1.Items
            item.backcolor = Color.White
        Next

        With LabelMobile
            .Text = ""
            .BackColor = Color.White
            .Hide()
        End With
    End Sub

    Sub Update_MailList()
        'clear the clipboard and reload
        MailList = ""
        Clipboard.Clear()
        Dim count As Integer = 0
        'append all e-mail addresses to MailList
        For Each item In LV1.Items
            If item.subitems(1).text = ChrW(9993) Then
                MailList = MailList & item.SubItems(3).Text & " <" & item.SubItems(6).Text & ">,"
                count += 1
            End If
        Next
        If MailList <> "" Then
            'remove trailing comma
            If MailList.EndsWith(",") Then
                MailList = MailList.Substring(0, MailList.Length - 1)
            End If
            Clipboard.SetText(MailList)
        End If
        LabelMail.Show()
        LabelMail.Text = count
    End Sub

    Sub LabelMail_Click(sender As Object, e As EventArgs) Handles LabelMail.Click
        For Each item In LV1.Items
            item.subitems(1).text = ""
        Next
        Clipboard.Clear()
        LabelMail.Hide()
    End Sub

    Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("Another Instance of this process is already running", MsgBoxStyle.OkOnly)
            Application.Exit()
        End If
        'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
        Dim culture_info As New CultureInfo("he-IL")
        Dim TypeOfLanguage As CultureInfo = New CultureInfo("he-IL")
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
        'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
        With LV1
            .Size = CType(New Point(315, 390), Drawing.Size)
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("0", 0)
            .Columns.Add("1", 25)
            .Columns.Add("2 טל", 40, HorizontalAlignment.Left)
            .Columns.Add("שם 3" & Space(10), 186, HorizontalAlignment.Right)
            .Columns.Add("דירה 4", 40, HorizontalAlignment.Right)
            .Columns.Add("5 Mobile", 0)
            .Columns.Add("6 Mail", 0)
        End With

        Location = New Point(400, 50)

        lvwColumnSorter = New ListViewColumnSorter()
        LV1.ListViewItemSorter = lvwColumnSorter

        LoadLV1()
        'sort LV1 by name
        LabelNames_Click(sender, e)
        TBName.Select()
        LblMail.Text = ChrW(9993)
        LblMail.Image = Nothing
        LabelHelp.Hide()
        LabelMail.Hide()
        LabelMobile.Hide()
        MailList = ""
    End Sub

    Private Sub LV1_MouseMove(sender As Object, e As MouseEventArgs) Handles LV1.MouseMove
        SendKeys.Send("{ESCAPE}")
        DeSelect()
    End Sub

    Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Sub Form_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True 'Sets the variable drag to true.
        mouseX = Cursor.Position.X - Me.Left : mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Sub LabelExit_Click(sender As Object, e As EventArgs) Handles LabelExit.Click
        Clipboard.Clear()
        End
    End Sub

    Sub Form_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mouseY : Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Sub LabelApartment_Click(sender As Object, e As EventArgs) Handles LabelApartment.Click
        Dim args As ColumnClickEventArgs = New ColumnClickEventArgs(4)
        LV1_ColumnClick(Me, args)
        TBName.Clear()
    End Sub

    Sub LabelNames_Click(sender As Object, e As EventArgs) Handles LabelNames.Click
        Dim args As ColumnClickEventArgs = New ColumnClickEventArgs(3)
        LV1_ColumnClick(Me, args)
        TBName.Clear()
    End Sub

    Sub Controls_Click(sender As Object, e As EventArgs) Handles TBName.Click, LabelMobile.Click
        For Each item In LV1.Items
            item.backcolor = Color.White
        Next
        With LabelMobile
            .Text = ""
            .Hide()
        End With
    End Sub

    Sub LabelInfo_MouseDown(sender As Object, e As EventArgs) Handles LabelInfo.MouseDown
        LV1.Enabled = False
        LV1.ForeColor = Color.Gray
        LabelHelp.BackColor = Color.Yellow
        LabelHelp.Show()
    End Sub

    Sub LabelInfo_MouseUp(sender As Object, e As EventArgs) Handles LabelInfo.MouseUp
        LV1.Enabled = True
        LV1.ForeColor = Color.Black
        LabelHelp.Hide()
    End Sub

    Sub LV1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles LV1.ColumnClick
        If e.Column < 3 Then Exit Sub
        ' Determine if clicked column is the sorted column.
        If e.Column = lvwColumnSorter.SortColumn Then
            ' Reverse the current sort direction for this column.
            If lvwColumnSorter.Order = SortOrder.Ascending Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else            ' sort by name, ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        LV1.Items.Clear()
        LoadLV1()
        LV1.Sort()

        For Each item In LV1.Items
            ' "תת_" was needed for sorting and is not needed anymore
            item.subitems(3).text = item.subitems(3).text.replace("תת_", "")
        Next

        'if sorted by appartment number, remove non-tenants
        If e.Column = 4 Then
            For i As Integer = LV1.Items.Count - 1 To 0 Step -1
                If LV1.Items(i).SubItems(4).Text = "" Then
                    LV1.Items.RemoveAt(i)
                End If
            Next
        End If
    End Sub
End Class

'@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
Public Class ListViewColumnSorter
    Implements IComparer
    Dim ColumnToSort As Integer, OrderOfSort As SortOrder, ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ColumnToSort = 0
        OrderOfSort = SortOrder.None
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    'returns "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX, listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects
        listviewX = DirectCast(x, ListViewItem)
        listviewY = DirectCast(y, ListViewItem)

        compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)

        ' Calculate correct return value based on object comparison
        If OrderOfSort = SortOrder.Ascending Then
            Return compareResult
        ElseIf OrderOfSort = SortOrder.Descending Then
            Return (-compareResult)
        Else
            Return 0
        End If

    End Function

    'Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    Public Property SortColumn() As Integer
        Set(ByVal value As Integer)
            ColumnToSort = value
        End Set
        Get
            Return ColumnToSort
        End Get
    End Property

    'Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    Public Property Order() As SortOrder
        Set(ByVal value As SortOrder)
            OrderOfSort = value
        End Set
        Get
            Return OrderOfSort
        End Get
    End Property

End Class

