
# Create class and object
class Person:
    
    # define constructor
    def __init__(self, name, age):
        self.name = name
        self.age = age

    # define method
    def displayAge(self):
        print("My age is " + str(self.age) )    #can't concat string and integer so using str()

# define object and invoke variable/method
p1 = Person("John", 36)
print(p1.name)
p1.displayAge()