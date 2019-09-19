<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNachrichtSenden = New System.Windows.Forms.Button()
        Me.btnHinzufügen = New System.Windows.Forms.Button()
        Me.lbNachrichtenAnzeigen = New System.Windows.Forms.ListBox()
        Me.txtNachrichtenSenden = New System.Windows.Forms.TextBox()
        Me.txtTeilnehmerHinzufügen = New System.Windows.Forms.TextBox()
        Me.lblNachrichtenAnzeigen = New System.Windows.Forms.Label()
        Me.lblNachrichtEingeben = New System.Windows.Forms.Label()
        Me.lblTeilnehmerHinzufügen = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnNachrichtSenden
        '
        Me.btnNachrichtSenden.Location = New System.Drawing.Point(622, 118)
        Me.btnNachrichtSenden.Name = "btnNachrichtSenden"
        Me.btnNachrichtSenden.Size = New System.Drawing.Size(96, 34)
        Me.btnNachrichtSenden.TabIndex = 0
        Me.btnNachrichtSenden.Text = "Senden"
        Me.btnNachrichtSenden.UseVisualStyleBackColor = True
        '
        'btnHinzufügen
        '
        Me.btnHinzufügen.Location = New System.Drawing.Point(622, 263)
        Me.btnHinzufügen.Name = "btnHinzufügen"
        Me.btnHinzufügen.Size = New System.Drawing.Size(96, 37)
        Me.btnHinzufügen.TabIndex = 1
        Me.btnHinzufügen.Text = "Hinzufügen"
        Me.btnHinzufügen.UseVisualStyleBackColor = True
        '
        'lbNachrichtenAnzeigen
        '
        Me.lbNachrichtenAnzeigen.FormattingEnabled = True
        Me.lbNachrichtenAnzeigen.ItemHeight = 16
        Me.lbNachrichtenAnzeigen.Location = New System.Drawing.Point(115, 124)
        Me.lbNachrichtenAnzeigen.Name = "lbNachrichtenAnzeigen"
        Me.lbNachrichtenAnzeigen.Size = New System.Drawing.Size(195, 212)
        Me.lbNachrichtenAnzeigen.TabIndex = 2
        '
        'txtNachrichtenSenden
        '
        Me.txtNachrichtenSenden.Location = New System.Drawing.Point(416, 124)
        Me.txtNachrichtenSenden.Name = "txtNachrichtenSenden"
        Me.txtNachrichtenSenden.Size = New System.Drawing.Size(100, 22)
        Me.txtNachrichtenSenden.TabIndex = 3
        '
        'txtTeilnehmerHinzufügen
        '
        Me.txtTeilnehmerHinzufügen.Location = New System.Drawing.Point(416, 270)
        Me.txtTeilnehmerHinzufügen.Name = "txtTeilnehmerHinzufügen"
        Me.txtTeilnehmerHinzufügen.Size = New System.Drawing.Size(100, 22)
        Me.txtTeilnehmerHinzufügen.TabIndex = 4
        '
        'lblNachrichtenAnzeigen
        '
        Me.lblNachrichtenAnzeigen.AutoSize = True
        Me.lblNachrichtenAnzeigen.Location = New System.Drawing.Point(135, 75)
        Me.lblNachrichtenAnzeigen.Name = "lblNachrichtenAnzeigen"
        Me.lblNachrichtenAnzeigen.Size = New System.Drawing.Size(76, 17)
        Me.lblNachrichtenAnzeigen.TabIndex = 5
        Me.lblNachrichtenAnzeigen.Text = "Nchrichten"
        '
        'lblNachrichtEingeben
        '
        Me.lblNachrichtEingeben.AutoSize = True
        Me.lblNachrichtEingeben.Location = New System.Drawing.Point(407, 81)
        Me.lblNachrichtEingeben.Name = "lblNachrichtEingeben"
        Me.lblNachrichtEingeben.Size = New System.Drawing.Size(131, 17)
        Me.lblNachrichtEingeben.TabIndex = 6
        Me.lblNachrichtEingeben.Text = "Nachricht eingeben"
        '
        'lblTeilnehmerHinzufügen
        '
        Me.lblTeilnehmerHinzufügen.AutoSize = True
        Me.lblTeilnehmerHinzufügen.Location = New System.Drawing.Point(395, 231)
        Me.lblTeilnehmerHinzufügen.Name = "lblTeilnehmerHinzufügen"
        Me.lblTeilnehmerHinzufügen.Size = New System.Drawing.Size(153, 17)
        Me.lblTeilnehmerHinzufügen.TabIndex = 7
        Me.lblTeilnehmerHinzufügen.Text = "Teilnehmer hinzufügen"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.lblTeilnehmerHinzufügen)
        Me.Controls.Add(Me.lblNachrichtEingeben)
        Me.Controls.Add(Me.lblNachrichtenAnzeigen)
        Me.Controls.Add(Me.txtTeilnehmerHinzufügen)
        Me.Controls.Add(Me.txtNachrichtenSenden)
        Me.Controls.Add(Me.lbNachrichtenAnzeigen)
        Me.Controls.Add(Me.btnHinzufügen)
        Me.Controls.Add(Me.btnNachrichtSenden)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNachrichtSenden As Button
    Friend WithEvents btnHinzufügen As Button
    Friend WithEvents lbNachrichtenAnzeigen As ListBox
    Friend WithEvents txtNachrichtenSenden As TextBox
    Friend WithEvents txtTeilnehmerHinzufügen As TextBox
    Friend WithEvents lblNachrichtenAnzeigen As Label
    Friend WithEvents lblNachrichtEingeben As Label
    Friend WithEvents lblTeilnehmerHinzufügen As Label
End Class
