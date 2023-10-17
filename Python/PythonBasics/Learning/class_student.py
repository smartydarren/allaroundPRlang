class StudentLala:

	def __init__(self,name,gender,age,major,gpa,is_on_probation):# These are parameters in the class
		self.name = name #The objects .name = the actual argument passed
		self.gender = gender
		self.age = age
		self.major = major
		self.gpa = gpa
		self.is_on_probation = is_on_probation

	#class function
	def on_honor_roll(self):
		if self.gpa > 3.5:
			return True
		else:
			return False
        


'''
# main file code
from Learning.class_student import StudentLala

student1 = StudentLala('jim','M',36,'business',5.1,False)
student2 = StudentLala('Pam','F',35,'arts',4.1,True)
print(student1.name,student1.gpa)
print(student2.name,student2.gpa)

result = ''
result = student1.on_honor_roll()

if result is True:
    print('Student is on the honors roll')
else:
    print('No honors acheived')     
'''
        


