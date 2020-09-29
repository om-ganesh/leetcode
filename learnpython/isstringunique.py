#https://www.lintcode.com/problem/unique-characters/description
class Solution:
    """
    @param: str: A string
    @return: a boolean
    """
    def isUnique(self, str):
        # write your code here
        s = set()
        for ch in str:
            if ch in s:
                return False
            s.add(ch)
        return True

sln = Solution()
print(sln.isUnique("abc___"))
