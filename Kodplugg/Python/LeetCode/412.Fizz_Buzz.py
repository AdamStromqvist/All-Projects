class Solution(object):
    def fizzBuzz(self, n):
        """
        :type n: int
        :rtype: List[str]
        """

        arr = []
        a = "FizzBuzz"
        b = "Fizz"
        c = "Buzz"

        for i in range(1, n + 1):
            if i % 3 == 0 and i % 5 == 0:
                arr.append(a)
            elif i % 3 == 0:
                arr.append(b)
            elif i % 5 == 0:
                arr.append(c)
            else:
                arr.append(str(i))
        
        return arr

solution = Solution()
result = solution.fizzBuzz(15)
print(result)