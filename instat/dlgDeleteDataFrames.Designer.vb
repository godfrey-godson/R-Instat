﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgDeleteDataFrames
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
        Me.lblDataframes = New System.Windows.Forms.Label()
        Me.lblAppendToDataframe = New System.Windows.Forms.Label()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrReceiverDataFrames = New instat.ucrReceiverMultiple()
        Me.ucrSelectorDataFramesToDelete = New instat.ucrSelectorAddRemove()
        Me.SuspendLayout()
        '
        'lblDataframes
        '
        Me.lblDataframes.AutoSize = True
        Me.lblDataframes.Location = New System.Drawing.Point(12, 17)
        Me.lblDataframes.Name = "lblDataframes"
        Me.lblDataframes.Size = New System.Drawing.Size(70, 13)
        Me.lblDataframes.TabIndex = 0
        Me.lblDataframes.Text = "Data Frames:"
        '
        'lblAppendToDataframe
        '
        Me.lblAppendToDataframe.AutoSize = True
        Me.lblAppendToDataframe.Location = New System.Drawing.Point(253, 17)
        Me.lblAppendToDataframe.Name = "lblAppendToDataframe"
        Me.lblAppendToDataframe.Size = New System.Drawing.Size(115, 13)
        Me.lblAppendToDataframe.TabIndex = 2
        Me.lblAppendToDataframe.Text = "Selected Data Frames:"
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(10, 177)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(405, 52)
        Me.ucrBase.TabIndex = 4
        '
        'ucrReceiverDataFrames
        '
        Me.ucrReceiverDataFrames.AutoSize = True
        Me.ucrReceiverDataFrames.frmParent = Me
        Me.ucrReceiverDataFrames.Location = New System.Drawing.Point(253, 33)
        Me.ucrReceiverDataFrames.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverDataFrames.Name = "ucrReceiverDataFrames"
        Me.ucrReceiverDataFrames.Selector = Nothing
        Me.ucrReceiverDataFrames.Size = New System.Drawing.Size(122, 104)
        Me.ucrReceiverDataFrames.strNcFilePath = ""
        Me.ucrReceiverDataFrames.TabIndex = 3
        Me.ucrReceiverDataFrames.ucrSelector = Nothing
        '
        'ucrSelectorDataFramesToDelete
        '
        Me.ucrSelectorDataFramesToDelete.AutoSize = True
        Me.ucrSelectorDataFramesToDelete.bShowHiddenColumns = False
        Me.ucrSelectorDataFramesToDelete.Location = New System.Drawing.Point(10, 33)
        Me.ucrSelectorDataFramesToDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorDataFramesToDelete.Name = "ucrSelectorDataFramesToDelete"
        Me.ucrSelectorDataFramesToDelete.Size = New System.Drawing.Size(216, 141)
        Me.ucrSelectorDataFramesToDelete.TabIndex = 1
        '
        'dlgDeleteDataFrames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(438, 236)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.lblDataframes)
        Me.Controls.Add(Me.lblAppendToDataframe)
        Me.Controls.Add(Me.ucrReceiverDataFrames)
        Me.Controls.Add(Me.ucrSelectorDataFramesToDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDeleteDataFrames"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Data Frames"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents lblDataframes As Label
    Friend WithEvents lblAppendToDataframe As Label
    Friend WithEvents ucrReceiverDataFrames As ucrReceiverMultiple
    Friend WithEvents ucrSelectorDataFramesToDelete As ucrSelectorAddRemove
End Class
