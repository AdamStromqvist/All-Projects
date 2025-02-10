class Solution:
    def isPalindrome(self, s):
        l = 0  # Pekare som startar från vänster
        r = len(s) - 1  # Pekare som startar från höger
        while l < r:
            if not s[l].isalnum():
                l += 1  # Hoppa över icke-alfanumeriska tecken från vänster
            elif not s[r].isalnum():
                r -= 1  # Hoppa över icke-alfanumeriska tecken från höger
            elif s[l].lower() == s[r].lower():
                l += 1  # Flytta vänster pekare åt höger
                r -= 1  # Flytta höger pekare åt vänster
            else:
                return False  # Om tecken inte matchar är det inte en palindrom
        return True  # Om hela loopen klarar sig utan problem, är strängen en palindrom

solution = Solution()

# Testa med en enkel palindrom
result1 = solution.isPalindrome("A man, a plan, a canal: Panama")
print(result1)  # Output: True

# Testa med en sträng som inte är en palindrom
result2 = solution.isPalindrome("hello")
print(result2)  # Output: False

# Testa med en palindrom utan specialtecken
result3 = solution.isPalindrome("racecar")
print(result3)  # Output: True