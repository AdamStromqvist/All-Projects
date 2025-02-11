# Detta kommando är till för att lösa uppgiften med Counter, dvs lösning 2
from collections import Counter

class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        
        # Metod 1
        if len(s) != len(t):
            return False
        
        countS, countT = {}, {}

        for i in range(len(s)):
            countS[s[i]] = 1 + countS.get(s[i], 0)
            countT[t[i]] = 1 + countT.get(t[i], 0)
        for c in countS:
            if countS[c] != countT.get(c, 0):
                return False
        
        return True
    
    # Metod 2: Med Counter
    def isAnagramCounter(self, s: str, t: str) -> bool:
        return Counter(s) == Counter(t)

    # Metod 3: Med sorted
    def isAnagramSorted(self, s: str, t: str) -> bool:
        return sorted(s) == sorted(t)
    

# Klass för att testa alla lösningar
class SolutionTester:
    def __init__(self):
        self.solution = Solution()

    def testAllMethods(self, test_cases):
        print("Testing all methods:")
        for s, t, expected in test_cases:
            manual = self.solution.isAnagram(s, t)
            counter = self.solution.isAnagramCounter(s, t)
            sorted_method = self.solution.isAnagramSorted(s, t)
            
            print(f"Test case: s='{s}', t='{t}'")
            print(f"  Expected: {expected}")
            print(f"  isAnagram (Manual): {manual}")
            print(f"  isAnagramCounter: {counter}")
            print(f"  isAnagramSorted: {sorted_method}")
            print(f"  All methods match expected: {manual == counter == sorted_method == expected}\n")


# Testfall
test_cases = [
    ("anagram", "nagaram", True),  # Positivt fall
    ("rat", "car", False),        # Negativt fall
    ("a", "ab", False),           # Negativt fall
    ("", "", True),               # Positivt fall
    ("hello", "olelh", True),     # Positivt fall
    ("python", "typhon", True),   # Positivt fall
    ("abc", "def", False)         # Negativt fall
]

# Kör testerna
tester = SolutionTester()
tester.testAllMethods(test_cases)




