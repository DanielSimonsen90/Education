ControlFocus("test", "", "Edit1")

Local $aArray = ["Hvor", "hurtigt", "kan", "du", "læse?"]

For $i = 0 To UBound($aArray) - 1
	Sleep(100)
	ControlSetText("test", "", "Edit1", $aArray[$i])
Next
ControlSetText("test", "", "Edit1", "")
