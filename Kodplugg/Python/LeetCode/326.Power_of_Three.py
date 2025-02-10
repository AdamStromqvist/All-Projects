class Solution(object):
    def isPowerOfThree(self, n):
        """
        :type n: int
        :rtype: bool
        """
        # Största potensen av 3 som ryms inom ett 32-bitars heltal är 3^19 = 1162261467
        max_power_of_three = 1162261467  # Detta är 3^19
        
        # Kontrollera om n är en positiv divisor till 3^19
        return n > 0 and max_power_of_three % n == 0

# Exempelanvändning
solution = Solution()

# Testa med ett tal som är en potens av tre
result1 = solution.isPowerOfThree(27)  # 27 är 3^3
print(result1)  # Output: True

# Testa med ett tal som inte är en potens av tre
result2 = solution.isPowerOfThree(10)
print(result2)  # Output: False

# Testa med det största talet som är en potens av tre inom 32-bitars gränsen
result3 = solution.isPowerOfThree(1162261467)  # Detta är 3^19
print(result3)  # Output: True
