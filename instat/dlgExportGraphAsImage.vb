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
Public Class dlgExportGraphAsImage
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Private clsggSave As New RFunction

    Private Sub dlgExportGraphAsImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            InitialiseDialog()
            bFirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 556
        ucrInputFile.SetParameter(New RParameter("filename", 0))

        ucrSelectedGraphReceiver.SetParameter(New RParameter("plot", 1))
        ucrSelectedGraphReceiver.SetParameterIsRFunction()
        ucrSelectedGraphReceiver.SetItemType("graph")
        ucrSelectedGraphReceiver.bPrintGraph = False
        ucrSelectedGraphReceiver.strSelectorHeading = "Graphs"
        ucrSelectedGraphReceiver.Selector = ucrSelectorGraphAsImage
        ucrSelectedGraphReceiver.SetMeAsReceiver()
    End Sub

    Private Sub SetDefaults()
        clsggSave = New RFunction

        ucrInputFile.Reset()
        ucrSelectorGraphAsImage.Reset()
        ucrInputFile.SetName("")

        clsggSave.SetPackageName("ggplot2")
        clsggSave.SetRCommand("ggsave")
        ucrBase.clsRsyntax.SetBaseRFunction(clsggSave)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub TestOkEnabled()
        If Not ucrSelectedGraphReceiver.IsEmpty AndAlso Not ucrInputFile.IsEmpty Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim strCurrentFilePathName As String = ucrInputFile.GetText()
        Using dlgSave As New SaveFileDialog
            dlgSave.Title = "Save Graph As Image"
            dlgSave.Filter = "JPEG (*.jpeg)|*.jpeg|PNG(*.png)|*.png|BitMaP(*.bmp)|*.bmp|EPS(*.eps)|*.eps|PostScript(*.ps)|*.ps|SVG(*.svg)|*.svg|WMF(*.wmf)|*.wmf|PDF(*.pdf)|*.pdf"
            If String.IsNullOrEmpty(strCurrentFilePathName) Then
                dlgSave.FileName = ucrSelectedGraphReceiver.GetVariableNames(bWithQuotes:=False) 'give a suggestive name (from the reciver)
                dlgSave.InitialDirectory = frmMain.clsInstatOptions.strWorkingDirectory
            Else
                strCurrentFilePathName = strCurrentFilePathName.Replace("/", "\")
                dlgSave.FileName = Path.GetFileName(strCurrentFilePathName)
                dlgSave.InitialDirectory = Path.GetDirectoryName(strCurrentFilePathName) 'use the previous path as initial dir
            End If
            If DialogResult.OK = dlgSave.ShowDialog() Then
                ucrInputFile.SetName(dlgSave.FileName.Replace("\", "/")) 'R uses / slashes for file paths. so \ needs to be replaced
            End If
        End Using
    End Sub

    Private Sub ucrInputFile_Click() Handles ucrInputFile.ControlClicked
        cmdBrowse.PerformClick()
    End Sub

    Private Sub ucrCoreControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrSelectedGraphReceiver.ControlContentsChanged, ucrInputFile.ControlContentsChanged
        TestOkEnabled()
    End Sub
End Class