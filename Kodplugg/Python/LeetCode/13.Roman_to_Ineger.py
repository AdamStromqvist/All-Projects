class Solution(object):
    def romanToInt(self, s):
        """
        :type s: str
        :rtype: int
        """
        # Dictonary. Sätter ett värde till ett annat
        romanValues = {
            'I': 1,
            'V': 5,
            'X': 10,
            'L': 50,
            'C': 100,
            'D': 500,
            'M': 1000
        }
        

        total = 0
        prevValue = 0

        for char in reversed(s): 
            """
            Går igenom strängen baklänges. 
            Detta är viktigt eftersom romerska tal ibland måste subtraheras 
            beroende på deras position (t.ex., IV = 4 där 'I' subtraheras från 'V').
            """
            currentValue = romanValues[char]

            if currentValue < prevValue:
                total -= currentValue
            else:
                total += currentValue
            
            prevValue = currentValue
        
        return total

solution = Solution()

# Testfall 1: Enkel romersk siffra
s1 = "III"  # 3
print(f"{s1} omvandlas till {solution.romanToInt(s1)}")  # Förväntat: 3

# Testfall 2: Komplex romersk siffra med subtraktion
s2 = "IV"  # 4
print(f"{s2} omvandlas till {solution.romanToInt(s2)}")  # Förväntat: 4

# Testfall 3: En vanlig siffra
s3 = "IX"  # 9
print(f"{s3} omvandlas till {solution.romanToInt(s3)}")  # Förväntat: 9

# Testfall 4: Kombinerar stora och små värden
s4 = "LVIII"  # 58
print(f"{s4} omvandlas till {solution.romanToInt(s4)}")  # Förväntat: 58

# Testfall 5: Stor romersk siffra
s5 = "MCMXCIV"  # 1994
print(f"{s5} omvandlas till {solution.romanToInt(s5)}")  # Förväntat: 1994