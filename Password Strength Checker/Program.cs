using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Password_Strength_Checker {

    internal class Program {

        static void Main() {
            Console.Write("Enter a password to check its strength: ");
            string password = Console.ReadLine();

            string strength = CheckPasswordStrength(password);
            Console.WriteLine($"Password Strength: {strength}");
        }

        /// <summary>
        ///     Evaluates the strength of a given password.
        /// </summary>
        /// <param name="password">The password to check</param>
        /// <returns>A string indicating password strength: Weak, Medium, or Strong</returns>
        static string CheckPasswordStrength(string password) {

            // Validate that the password is not null or empty
            if (string.IsNullOrEmpty(password)) {
                return "Invalid (Password cannot be empty)";
            }

            // Initialize strength score to 0
            int score = 0;

            // If password has at least 8 characters
            if (password.Length >= 8) {
                score++;
            }

            // If password has 12 or more characters
            if (password.Length >= 12) {
                score++;
            }

            // If the password contains a lowercase letter
            if (Regex.IsMatch(password, @"[a-z]")) {
                score++;
            }

            // If the password contains at least one uppercase letter
            if (Regex.IsMatch(password, @"[A-Z]")) {
                score++;
            }

            // If the password contains at least one numeric digit
            if (Regex.IsMatch(password, @"\d")) {
                score++;
            }

            // If the password contains at least one special character
            if (Regex.IsMatch(password, @"[\W_]")) {
                score++;
            }

            // If score is 2 or lower, password is Weak
            if (score <= 2) {
                return "Weak";
            }

            // If score is between 3 and 4, password is Medium
            if (score <= 4) {
                return "Medium";
            }

            // If score is 5 or more, password is Strong
            return "Strong";
        }
    }
}
