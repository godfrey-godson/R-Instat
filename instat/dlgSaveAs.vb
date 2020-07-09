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

Imports System.IO
Imports instat.Translations
Public Class dlgSaveAs
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsSaveFunction As New RFunction

    Private Sub dlgSaveAs_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 332

        ucrInputFilePath.SetParameter(New RParameter("file", 0))
        ucrInputFilePath.IsReadOnly = True

        lblConfirm.Text = "Click Ok to confirm the save"
    End Sub

    Private Sub SetDefaults()
        clsSaveFunction = New RFunction

        ucrInputFilePath.Reset()
        ucrInputFilePath.SetName("")

        clsSaveFunction.SetRCommand("saveRDS")
        clsSaveFunction.AddParameter("object", frmMain.clsRLink.strInstatDataObject)

        ucrBase.clsRsyntax.SetBaseRFunction(clsSaveFunction)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
        TestOKEnabled()
    End Sub

    Private Sub TestOKEnabled()
        If Not ucrInputFilePath.IsEmpty() Then
            lblConfirm.Show()
            ucrBase.OKEnabled(True)
        Else
            lblConfirm.Hide()
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
    End Sub

    Private Sub ucrBase_ClickOk(sender As Object, e As EventArgs) Handles ucrBase.ClickOk
        frmMain.strSaveFilePath = ucrInputFilePath.GetText()
        frmMain.clsRecentItems.addToMenu(Replace(ucrInputFilePath.GetText(), "/", "\"))
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdChooseFile.Click
        Dim strCurrentFilePathName As String = ucrInputFilePath.GetText()
        Using dlgSave As New SaveFileDialog
            dlgSave.Title = "Save Data File"
            dlgSave.Filter = "RDS Data file (*.RDS)|*.RDS"
            If String.IsNullOrEmpty(strCurrentFilePathName) Then
                dlgSave.InitialDirectory = frmMain.clsInstatOptions.strWorkingDirectory
            Else
                strCurrentFilePathName = strCurrentFilePathName.Replace("/", "\")
                dlgSave.FileName = Path.GetFileName(strCurrentFilePathName)
                dlgSave.InitialDirectory = Path.GetDirectoryName(strCurrentFilePathName)
            End If
            If DialogResult.OK = dlgSave.ShowDialog() Then
                ucrInputFilePath.SetName(dlgSave.FileName.Replace("\", "/"))
            End If
        End Using
    End Sub

    Private Sub ucrInputFilePath_Click() Handles ucrInputFilePath.ControlClicked
        cmdChooseFile.PerformClick()
    End Sub

    Private Sub ucrInputFilePath_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrInputFilePath.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class
