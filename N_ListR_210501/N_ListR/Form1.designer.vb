<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LV1 = New System.Windows.Forms.ListView()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelExit = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelPhone = New System.Windows.Forms.Label()
        Me.LabelNames = New System.Windows.Forms.Label()
        Me.LabelApartment = New System.Windows.Forms.Label()
        Me.LblMail = New System.Windows.Forms.Label()
        Me.TBInfo = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelHelp = New System.Windows.Forms.Label()
        Me.LabelMobile = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sink = New System.Windows.Forms.Button()
        Me.LabelMail = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LV1
        '
        Me.LV1.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LV1, "LV1")
        Me.LV1.FullRowSelect = True
        Me.LV1.HideSelection = False
        Me.LV1.HoverSelection = True
        Me.LV1.LabelEdit = True
        Me.LV1.Name = "LV1"
        Me.LV1.UseCompatibleStateImageBehavior = False
        Me.LV1.View = System.Windows.Forms.View.Details
        '
        'LabelVersion
        '
        resources.ApplyResources(Me.LabelVersion, "LabelVersion")
        Me.LabelVersion.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelVersion.Name = "LabelVersion"
        '
        'LabelExit
        '
        resources.ApplyResources(Me.LabelExit, "LabelExit")
        Me.LabelExit.Name = "LabelExit"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'LabelInfo
        '
        resources.ApplyResources(Me.LabelInfo, "LabelInfo")
        Me.LabelInfo.Name = "LabelInfo"
        Me.ToolTip1.SetToolTip(Me.LabelInfo, resources.GetString("LabelInfo.ToolTip"))
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LabelPhone)
        Me.Panel1.Controls.Add(Me.LabelNames)
        Me.Panel1.Controls.Add(Me.LabelApartment)
        Me.Panel1.Controls.Add(Me.LblMail)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'LabelPhone
        '
        resources.ApplyResources(Me.LabelPhone, "LabelPhone")
        Me.LabelPhone.Name = "LabelPhone"
        Me.ToolTip1.SetToolTip(Me.LabelPhone, resources.GetString("LabelPhone.ToolTip"))
        '
        'LabelNames
        '
        resources.ApplyResources(Me.LabelNames, "LabelNames")
        Me.LabelNames.Name = "LabelNames"
        '
        'LabelApartment
        '
        resources.ApplyResources(Me.LabelApartment, "LabelApartment")
        Me.LabelApartment.Name = "LabelApartment"
        '
        'LblMail
        '
        resources.ApplyResources(Me.LblMail, "LblMail")
        Me.LblMail.Name = "LblMail"
        '
        'TBInfo
        '
        Me.TBInfo.BackColor = System.Drawing.Color.Gainsboro
        Me.TBInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TBInfo, "TBInfo")
        Me.TBInfo.Name = "TBInfo"
        '
        'LabelHelp
        '
        Me.LabelHelp.BackColor = System.Drawing.Color.Yellow
        resources.ApplyResources(Me.LabelHelp, "LabelHelp")
        Me.LabelHelp.Name = "LabelHelp"
        '
        'LabelMobile
        '
        Me.LabelMobile.BackColor = System.Drawing.Color.PapayaWhip
        Me.LabelMobile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.LabelMobile, "LabelMobile")
        Me.LabelMobile.Name = "LabelMobile"
        '
        'TBName
        '
        resources.ApplyResources(Me.TBName, "TBName")
        Me.TBName.Name = "TBName"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'sink
        '
        Me.sink.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.sink, "sink")
        Me.sink.Name = "sink"
        Me.sink.UseVisualStyleBackColor = False
        '
        'LabelMail
        '
        resources.ApplyResources(Me.LabelMail, "LabelMail")
        Me.LabelMail.Name = "LabelMail"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelMail)
        Me.Controls.Add(Me.sink)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBName)
        Me.Controls.Add(Me.LabelMobile)
        Me.Controls.Add(Me.LabelHelp)
        Me.Controls.Add(Me.TBInfo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelExit)
        Me.Controls.Add(Me.LV1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV1 As ListView
    Friend WithEvents LabelVersion As Label
    Friend WithEvents LabelExit As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelInfo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelApartment As Label
    Friend WithEvents LblMail As Label
    Friend WithEvents LabelPhone As Label
    Friend WithEvents TBInfo As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelNames As Label
    Friend WithEvents LabelHelp As Label
    Friend WithEvents LabelMobile As Label
    Friend WithEvents TBName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents sink As Button
    Friend WithEvents LabelMail As Label
End Class
