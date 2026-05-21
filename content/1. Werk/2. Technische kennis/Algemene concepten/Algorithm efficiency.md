---
aliases: [Big O Notation]
tags: Techniek
---

# Algorithm efficiency

An algorithm is a step-by-step sequence to perform some kind of action, including the error-catching logic flow. 

Consider an algorithm a set of **operations**. These operations process **input data** with an **input size**. To compare algorithms, make sure that you compare on the *same machine* with the same *input size* to see which algorithm is faster. 

We will use the **big O notation** to measure the efficiency of algorithms. This is borrowed from mathematics, but don't bother looking up the original meaning. 

An algorithm has the **time complexity** $O(f(n))$ if its number of operations grows bigger similar to (or slower than) the function $f(n)$ when the input size $n$ is a large number. 

## Growth rates
Common growth rates:
* $O(1)$ (**constant time**). The algorithm performs a constant number of operations. Maybe one, two, twenty-six, or two hundred – it doesn't matter. What is important is that it doesn't depend on the input size. Typical algorithms of this class include calculating the answer using a direct formula, printing a couple of values, all letters of the English alphabet, etc.
* $O(\log n)$ (**logarithmic time**). Perhaps a quick reminder on logarithms is necessary. We usually refer to logarithms of base 2; however, the base does not affect the class. By definition, $\log n$ equals the number of times $n$ must be divided by $2$ to get $1$. That being said, it should not be difficult to guess that such algorithms divide the input size into **halves** at each step. They are relatively fast: if the size of the input is huge, say, $2^{31}$ (programmers should know the importance of this number), the algorithm will perform approximately $\log_2(2^{31})= 31$ operations, which is pretty effective.
* $O(n)$ (**linear time**). The time is proportional to the input size, i.e., the time grows linearly as the input size increases. Often, such algorithms are iterated only once. They occur quite frequently, because it is usually necessary to go through every input element before calculating the final answer. This makes the $O(n)$ class one of the most effective classes in practice.
* $O(n^2)$ (**quadratic time**). Normally, such algorithms go through all pairs of input elements. Why? Well, mathematics is generous, it constantly provides us with important results: in this case, basic maths confirms that the number of unordered pairs in a set of n elements is equal to  to $\frac{n(n-1)}{2}$, which, as we will learn later in this topic, is $O(n^2)$. If you find it scary or difficult to understand, it is completely normal, it happens to the best of us. On the other hand, for those who are familiar with programming terms, the following sentence might come in handy: quadratic time algorithms usually contain two nested loops.
* $O(2^n)$ (**exponential time**). Just in case, let's mention that $2^n$ is the same as multiplying $2$ by itself $n$ times. Again, maths states that the number of subsets of a set of $n$ elements is equal to $2^n$, therefore, it is reasonable to expect that such algorithms scan all the subsets of the input elements. It is worth noting that this class is extremely inefficient in practice; even for small input sizes, the time taken by the algorithms will be remarkably high. 

Less common growth rates:
* $O(\sqrt{n})$ (**square root time**)
* $O(n \log n)$ (**log-linear time**)
* $O(n^k)$ (**polynomial time**)
* $O(n!)$ (**factorial time**)

![[Algorithm efficiency.png]]

## Calculating complexity
Basic properties of the Big O:
* **Ignore the constants.** As we discussed above, while calculating complexities, we focus solely on the behavior of our algorithm with large input sizes. Therefore, repeating some steps a constant number of times does not affect the complexity. For example, if you traverse $n$ elements $5$ times, we say that the algorithm's time complexity is $O(n)$, and not $O(5n)$. Indeed, there is no significant difference between $1 000 000 000$ and $5 000 000 000$ operations performed by the algorithm. In either case, we conclude that it is relatively slow. Formally, we write $c\cdot O(n) = O(n)$. It is similar for the rest of the complexity classes.
* **Applying a procedure $n$ times.** What if you need to go over $n$ elements $n$ times? It is not a constant anymore, as it depends on the input size. In this case, the time complexity becomes $O(n^2)$. It's simple: you do $n$ times as an action proportional to $n$, which means the result is proportional to $n^2$. In big O notation, we write it as as $n\cdot O(n) = O(n^2)$.
* **Smaller terms do not matter.** Another common case is when after doing some actions, you need to do something else. For instance, you traverse $n$ elements $n$ times and then traverse $n$ elements again. In this case, the complexity is still $O(n^2)$. Additional $n$ actions do not affect your complexity, which is proportional to $n^2$. In big O notation, it looks like this: $O(n)+O(n^2) = O(n^2)$. All in all, always keep the largest term in Big O and forget about all others. It is rather easy to understand which terms are larger based on the order provided in the previous section. 