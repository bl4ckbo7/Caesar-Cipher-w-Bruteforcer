Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listBox.Hide()
    End Sub

    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click

        Try
            Dim textPlain As String = txtText.Text
            Dim ciphertext As String
            Dim shift As Integer = txtShift.Text
            Dim cipherChars(textPlain.Length) As Char

            For i As Integer = 0 To textPlain.Length - 1 Step 1

                If Char.IsLetter(textPlain(i)) And Char.IsLower(textPlain(i)) And ((Convert.ToInt32(Convert.ToChar(textPlain(i))) + shift) > 122) Then 'If Decimal Equivalent is greater 122

                    cipherChars(i) = Char.ToUpper(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textPlain(i))) + shift) - 26))

                ElseIf Char.IsLetter(textPlain(i)) And Char.IsLower(textPlain(i)) And ((Convert.ToInt32(Convert.ToChar(textPlain(i))) + shift) <= 122) Then 'If Decimal Equivalent is less 122

                    cipherChars(i) = Char.ToUpper(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textPlain(i))) + shift)))

                ElseIf Char.IsDigit(textPlain(i)) Then 'If character is digit

                    cipherChars(i) = Convert.ToChar(Convert.ToInt32(textPlain(i)))

                Else

                    MessageBox.Show("Plaintext should be Lowercase And Ciphertext should be Uppercase !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End

                End If

            Next i

            ciphertext = New String(cipherChars) 'Convert an array of characters to string object

            txtText.Text = ciphertext

        Catch ex As Exception
            MessageBox.Show("There is something wrong in your Input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click

        Try

            Dim textCiph As String = txtText.Text
            Dim plaintext As String
            Dim shift As Integer = txtShift.Text
            Dim plainChars(textCiph.Length) As Char

            For j As Integer = 0 To textCiph.Length - 1 Step 1

                If Char.IsLetter(textCiph(j)) And Char.IsUpper(textCiph(j)) And ((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) < 65) Then 'If Decimal Equivalent is less than 65

                    plainChars(j) = Char.ToLower(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) + 26))

                ElseIf Char.IsLetter(textCiph(j)) And Char.IsUpper(textCiph(j)) And ((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) >= 65) Then 'If Decimal Equivalent is less than or equal 65

                    plainChars(j) = Char.ToLower(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift)))

                ElseIf Char.IsDigit(textCiph(j)) Then 'If character is digit

                    plainChars(j) = Convert.ToChar(Convert.ToInt32(textCiph(j)))

                Else

                    MessageBox.Show("Plaintext should be Lowercase And Ciphertext should be Uppercase !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End

                End If

            Next j

            plaintext = New String(plainChars) 'Convert an array of characters to string object

            txtText.Text = plaintext

        Catch ex As Exception
            MessageBox.Show("There is something wrong in your Input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBrute_Click(sender As Object, e As EventArgs) Handles btnBrute.Click

        txtText.Hide()
        listBox.Show()
        txtShift.Enabled = False

        btnEncrypt.Enabled = False
        btnDecrypt.Enabled = False

        Try

            Dim textCiph As String = txtText.Text
            Dim plaintext As String
            Dim shift As Integer = 0
            Dim k As Integer = 0
            Dim plainChars(textCiph.Length) As Char

            Do While shift < 26

                For j As Integer = 0 To textCiph.Length - 1 Step 1

                    If Char.IsLetter(textCiph(j)) And Char.IsUpper(textCiph(j)) And ((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) < 65) Then 'If Decimal Equivalent is less than 65

                        plainChars(j) = Char.ToLower(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) + 26))

                    ElseIf Char.IsLetter(textCiph(j)) And Char.IsUpper(textCiph(j)) And ((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift) >= 65) Then 'If Decimal Equivalent is less than or equal 65

                        plainChars(j) = Char.ToLower(Convert.ToChar((Convert.ToInt32(Convert.ToChar(textCiph(j))) - shift)))

                    ElseIf Char.IsDigit(textCiph(j)) Then 'If character is digit

                        plainChars(j) = Convert.ToChar(Convert.ToInt32(textCiph(j)))

                    Else

                        MessageBox.Show("Plaintext should be Lowercase And Ciphertext should be Uppercase !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End

                    End If

                Next j

                plaintext = New String(plainChars) 'Convert an array of characters to string object
                listBox.Items.Add("Key :" & vbTab & shift & vbTab & "Plaintext :" & vbTab & plaintext & vbTab)

                shift += 1

            Loop

        Catch ex As Exception
            MessageBox.Show("There is something wrong in your Input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
