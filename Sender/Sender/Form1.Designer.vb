<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Stop_Transmitting = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.audioBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Stop_Transmitting
        '
        Me.Stop_Transmitting.Location = New System.Drawing.Point(313, 119)
        Me.Stop_Transmitting.Name = "Stop_Transmitting"
        Me.Stop_Transmitting.Size = New System.Drawing.Size(75, 23)
        Me.Stop_Transmitting.TabIndex = 6
        Me.Stop_Transmitting.Text = "Stop"
        Me.Stop_Transmitting.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(90, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(298, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "192.168.208.165"
        '
        'audioBtn
        '
        Me.audioBtn.Location = New System.Drawing.Point(90, 119)
        Me.audioBtn.Name = "audioBtn"
        Me.audioBtn.Size = New System.Drawing.Size(75, 23)
        Me.audioBtn.TabIndex = 9
        Me.audioBtn.Text = "Send"
        Me.audioBtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(199, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 189)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.audioBtn)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Stop_Transmitting)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Stop_Transmitting As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents audioBtn As Button
    Friend WithEvents Button1 As Button
End Class
