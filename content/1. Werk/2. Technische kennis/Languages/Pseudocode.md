---
tags: Techniek
---
# Pseudocode
**Pseudocode** is a special artificial language that stands somewhere between "human" language and code. When removing all language-specific features from a program, we are left with its "logical core", which is the essense of any algorithm. It is an abstract way of explaining code; enough for humans to grasp it, but not specific enough for computers to execute it. Straight-up human language descriptions are too cumbersome.

```c
max(array)						// you receive an array somehow  
	if len(array) == 0			// compare the size of array with 0  
		return -1 				// empty array, no maximum  
  
	max = 0 					// assume that maximum is the 0  
   
	for i in [1, len(array)] 	// iterate over the array, array indices start at 1  
		if array[i] > max 		// if we find something greater, we change the maximum  
			max = array[i]  
   
	return max 					// our result
```

Same thing in Python:
```python
n = int(input()) 				# the size of array   
array = [] 						# empty array  
for i in range(n): 				# do something n times  
	array.append(int(input())) 	# add element to the array  
	
if n == 0: 						# empty array  
	print(-1)
	
else:  
	max = 0 					# current maximum  
	
	for i in array: 			# iterate over the array  
		if i > max:   
			max = i 			# update the maximum  
			
	print(max)
```