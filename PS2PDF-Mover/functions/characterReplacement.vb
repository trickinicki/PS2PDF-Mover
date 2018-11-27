Option Explicit On

Module characterReplacement
	Function properFilename(filename As String) As String

		Dim badCharcter As New List(Of String())

		'Bad for filesytem
		'^/:*?<>""
		badCharcter.Add(("^,-").Split(","))
		badCharcter.Add(("/,-").Split(","))
		badCharcter.Add((":,-").Split(","))
		badCharcter.Add(("*,-").Split(","))
		badCharcter.Add(("?,-").Split(","))
		badCharcter.Add(("<,-").Split(","))
		badCharcter.Add((">,-").Split(","))


		badCharcter.Add(("\328,Ä").Split(","))
		badCharcter.Add(("\336,Ö").Split(","))
		badCharcter.Add(("\334,Ü").Split(","))

		badCharcter.Add(("\344,ä").Split(","))
		badCharcter.Add(("\366,ö").Split(","))
		badCharcter.Add(("\374,ü").Split(","))

		badCharcter.Add(("\307,C").Split(","))  'Ç
		badCharcter.Add(("\347,C").Split(","))  'ç

		For Each aCharacter In badCharcter
			filename = filename.Replace(aCharacter(0), aCharacter(1))
		Next

		Do While filename.Contains("- -")
			filename = filename.Replace("- -", "-")
		Loop

		Do While filename.Contains("--")
			filename = filename.Replace("--", "-")
		Loop

		Do While filename.Contains("  ")
			filename = filename.Replace("  ", " ")
		Loop

		Return filename

	End Function


End Module
