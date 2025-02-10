class Solution(object):
    def removeElement(self, nums, val):
        # Pekare k som håller koll på positionen för nästa icke-matchande element
        k = 0
        
        # Loopar genom varje element i listan
        for i in range(len(nums)):
            # Om elementet inte är lika med val, kopiera det till position k
            if nums[i] != val:
                nums[k] = nums[i]
                k += 1
        
        # Returnerar antalet element som inte är lika med val
        return k

# Exempel på användning:
solution = Solution()
nums = [3, 2, 2, 3]
val = 3
length = solution.removeElement(nums, val)

# Skriv ut längden och de kvarvarande elementen i listan
print(f"Längd av kvarvarande element: {length}")
print(f"Modifierad lista: {nums[:length]}")