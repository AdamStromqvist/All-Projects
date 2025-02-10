class Solution(object):
    def twoSum(self, nums, target):
        seen = {}
        for i, num in enumerate(nums):
            if target - num in seen:
                return [seen[target - num], i]
            elif num not in seen:
                seen[num] = i

# Testfall
nums = [2, 7, 11, 15]
target = 9

solution = Solution()
result = solution.twoSum(nums, target)

print("Indicies för tal som summeras till {} är: {}".format(target, result))
