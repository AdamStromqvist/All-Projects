class Solution(object):
    def isPalindrome(self, x):
        if x < 0:
            return False
        
        x_str = str(x) # Gör om int till string

        return x_str == x_str[::-1]

# Testfall
solution = Solution()

# Testfall 1: Ett positivt palindromtal
x1 = 121
print(f"Är {x1} ett palindrom? {solution.isPalindrome(x1)}")  # Förväntat: True

# Testfall 2: Ett negativt tal som inte kan vara ett palindrom
x2 = -121
print(f"Är {x2} ett palindrom? {solution.isPalindrome(x2)}")  # Förväntat: False

# Testfall 3: Ett tal som inte är ett palindrom
x3 = 123
print(f"Är {x3} ett palindrom? {solution.isPalindrome(x3)}")  # Förväntat: False

# Testfall 4: Ett tal med endast en siffra, som alltid är ett palindrom
x4 = 7
print(f"Är {x4} ett palindrom? {solution.isPalindrome(x4)}")  # Förväntat: True