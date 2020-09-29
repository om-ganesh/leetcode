#https://www.lintcode.com/problem/rotate-string/description
class Solution:
    """
    @param str: An array of char
    @param offset: An integer
    @return: nothing
    """
    def rotateString(self, s, offset):
        # write your code here
        n = len(s)
        if n != 0:
            for _ in range(offset % n):
                s.insert(0,  s.pop())

# defining list of char (python don't have inbuilt array and list is used for generic collection)
str = ['a','b','c','d','e','f','g']
sln = Solution()
sln.rotateString(str, 2)
print(str)
