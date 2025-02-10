class Solution(object):
    def removeDuplicates(self, nums):
        # Om listan är tom, returnera 0
        if not nums:
            return 0
        
        # Initiera pekare för att hålla koll på platsen för unika element
        i = 0

        # Iterera genom listan med en andra pekare j
        for j in range(1, len(nums)):
            # Om nästa element är unikt, flytta det till nästa position efter i
            if nums[j] != nums[i]:
                i += 1
                nums[i] = nums[j]
        
        # Returnera antal unika element, vilket är i + 1
        return i + 1

# Exempel på användning:
solution = Solution()
nums = [1, 1, 2, 3, 3, 3, 4, 5]
length = solution.removeDuplicates(nums)

# Skriv ut längden och de unika värdena i listan
print(f"Längd av unika element: {length}")
print(f"Modifierad lista med unika element: {nums[:length]}")