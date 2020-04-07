﻿
Imports instat
Imports instat.Translations
Public Class dlgTidy
    Public bfirstload As Boolean = True
    Public bReset As Boolean = True
    Private bResetSubdialog As Boolean = False
    Private clsRSyntax As RSyntax
    Private clsTidy, clsMap_df As New RFunction

    Private Sub dlgTidy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bfirstload Then
            InitialiseDialog()
            bfirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()

        ucrModelReceiver.SetItemType("model")
        ucrModelReceiver.strSelectorHeading = "Model"
        ucrModelReceiver.SetParameterIsRFunction()
        ucrModelReceiver.Selector = ucrModelSelector
        ucrModelReceiver.bForceVariablesAsList = True

        ucrChkDisplayInOutput.SetText("Display in Output")
        ucrChkDisplayInOutput.Checked = True

        ucrModelSelector.SetParameter(New RParameter("data", 0))
        ucrModelSelector.SetParameterIsrfunction()

        ucrSaveNewDataFrame.SetCheckBoxText("Save New data frame")
        ucrSaveNewDataFrame.SetSaveTypeAsDataFrame()
        ucrSaveNewDataFrame.SetPrefix("tidy_dataframe")
        ucrSaveNewDataFrame.SetIsComboBox()
        ucrSaveNewDataFrame.SetDataFrameSelector(ucrModelSelector.ucrAvailableDataFrames)

        ucrModelReceiver.SetParameter(New RParameter(".x", 0))
        ucrModelReceiver.Selector = ucrModelSelector
        ucrModelReceiver.SetMeAsReceiver()


    End Sub

    Private Sub SetDefaults()

        clsMap_df = New RFunction

        ucrSaveNewDataFrame.Reset()
        ucrModelSelector.Reset()

        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        ucrBase.clsRsyntax.iCallType = 2

        clsMap_df.SetPackageName("purrr")
        clsMap_df.SetRCommand("map_df")

        clsMap_df.AddParameter(strParameterName:=".f", strParameterValue:="broom::tidy", iPosition:=1)
        clsMap_df.AddParameter(strParameterName:=".id", strParameterValue:=Chr(34) & "model" & Chr(34), iPosition:=2)

        ucrBase.clsRsyntax.iCallType = 2
        ucrBase.clsRsyntax.SetBaseRFunction(clsMap_df)
    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub TestOKEnabled()
        'Tests when ok can be enabled
        If ucrModelReceiver.IsEmpty OrElse Not ucrSaveNewDataFrame.IsComplete Then
            ucrBase.OKEnabled(False)
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub CoreControls_ControlContentsChanged() Handles ucrModelReceiver.ControlContentsChanged, ucrSaveNewDataFrame.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrChkDisplayInOutput_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkDisplayInOutput.ControlValueChanged
        If ucrChkDisplayInOutput.Checked Then
            ucrBase.clsRsyntax.iCallType = 2
        Else
            ucrBase.clsRsyntax.iCallType = 0
        End If
    End Sub
End Class