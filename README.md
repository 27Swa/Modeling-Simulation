# Pseudorandom Number Generation using Linear Congruential Generator (LCG)

## Overview

This project implements a **Linear Congruential Generator (LCG)** using **C#** to produce pseudorandom real numbers. It also includes an algorithm to determine the **cycle length** — i.e., how many unique values are generated before the sequence starts repeating.

## Project Objectives

1. **Implement the LCG algorithm** to generate pseudorandom real numbers in C#.
2. **Display the generated numbers in a table**, based on the number of iterations.
3. **Calculate and display the actual cycle length**, which is the number of unique values before a repeat occurs.

## Key Features

- Generates a sequence of real-valued pseudorandom numbers using the classical LCG method.
- Records each number along with its iteration count.
- Detects when a value repeats and calculates the length of the full cycle.
- Outputs results in a clear, user-friendly table.

## Technologies Used

- **Language:** C#
- **IDE:** Visual Studio / Visual Studio Code
- **.NET Framework**

## Algorithm

The LCG algorithm is defined by the recurrence relation:


The algorithm continues generating values until a previously seen number is repeated, marking the end of one full cycle.

## Output

- Table of all generated real numbers with corresponding iteration numbers
- Total number of unique values before repetition
- Clear indication of when the cycle repeats

---

## Team Members

This project was completed as a collaborative effort by:

- **Amina Nafiu**
- **Mark Maged**
- **Somaya Mohamed**
- **Sama Amr**
- **Sondos Wael**
