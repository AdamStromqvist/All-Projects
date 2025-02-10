class Solution(object):
    def hammingWeight(self, n):
        """
        :type n: int
        :rtype: int
        """
        n = bin(n)
        n = str(n)
        return n.count("1")

solution = Solution()
print(solution.hammingWeight(11))  # Output: 3
print(solution.hammingWeight(128)) # Output: 1
print(solution.hammingWeight(2147483645)) # Output: 30
