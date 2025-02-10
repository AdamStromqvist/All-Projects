class Solution(object):
    def isAnagram(self, s, t):
        """
        :type s: str
        :type t: str
        :rtype: bool
        """
        sorted_s = sorted(s)
        sorted_t = sorted(t)

        return sorted_s == sorted_t

# Creating an instance of the Solution class
solution = Solution()

# Checking if "silent" and "listen" are anagrams
result1 = solution.isAnagram("silent", "listen")

# Checking if "cow" and "pig" are anagrams
result2 = solution.isAnagram("cow", "pig")

# Printing the results
print(result1)  # Expected output: True
print(result2)  # Expected output: False
