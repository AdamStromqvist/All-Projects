class Solution:
    def hasDuplicate(self, nums: list[int]) -> bool:
        hashset = set()

        for n in nums:
            if n in hashset:
                return True
            hashset.add(n)
        return False

# Skapa en instans av Solution-klassen
solution = Solution()

# Testa med en lista som innehåller dubbletter
print(solution.hasDuplicate([1, 2, 3, 4, 5, 1]))  # Output: True

# Testa med en lista utan dubbletter
print(solution.hasDuplicate([1, 2, 3, 4, 5]))  # Output: False
