# Week 2 – *The Vertical Shift Anomaly*

## Elevators Shouldn’t Think
You thought you escaped the Trench Protocol’s recursion loop, but a new glitch has emerged—deeper, subtler.

Teo intercepted a signal stream inside a low-level elevator subsystem. It was meant to control vertical movement across simulation layers: up (`(`), down (`)`). 

Basic logic. Nothing dangerous.
Until now.

A test began failing. Not randomly—but consistently. Like it *wants* to fail. 

> Like it's sending a message.

Worse: traces of an obsolete subroutine labeled **🧝** have reappeared in the code. That symbol hasn’t been seen since the earliest builds of the simulation—back when the Matrix experimented with "seasonal behavior injectors."

Why is it here now?

The elevator’s logic is no longer deterministic. Some signals trigger irrational shifts. Others inject unexplained values. You suspect that part of the system has become **self-modifying**. It adapts based on what's inside the input. It thinks. Or pretends to.

```csharp
public static class Vertical
{
    public static int WhichFloor(string signalStream)
    {
        List<Tuple<char, int>> val = [];

        for (int i = 0; i < signalStream.Length; i++)
        {
            var c = signalStream[i];

            if (signalStream.Contains("🧝"))
            {
                int j;
                if (c == ')') j = 3;
                else j = -2;

                val.Add(new Tuple<char, int>(c, j));
            }
            else if (!signalStream.Contains("🧝"))
            {
                val.Add(new Tuple<char, int>(c, c == '(' ? 1 : -1));
            }
            else val.Add(new Tuple<char, int>(c, c == '(' ? 42 : -2));
        }

        int result = 0;
        foreach (var kp in val)
        {
            result += kp.Item2;
        }
        return result;
    }
}
```

## 🧑‍💻 Your Challenge
Dive into the code. First, **observe the behavior** of the elevator logic with different input streams. 

Try multiple cases. See how it reacts when the 🧝 symbol appears... and when it doesn’t.

Once you’ve understood the glitch, **patch the function**. Fix the logic. Stabilize the construct.

But don’t stop there.

> Apply the **Matrix Scout Rule** — *"Leave the matrix better than you found it."* (formerly known as the [Boy Scout Rule](https://snappify.com/blog/boy-scout-rule#what-is-the-boy-scout-rule))

This system may run, but it’s barely readable. Its intent is buried under magic numbers and nested conditionals from forgotten Operators.
Clean it. Clarify it. Refactor it so the next mind jacked into this logic sees purpose, not paranoia.

This is your signature in the Matrix.

Make it count.

> *“There’s no floor, Neo. There’s only state.”*
> – Teo, Operator of Node-Δ12

## ☕ Reflect
Take a moment to reflect on your intervention inside the construct. Consider these questions:

1. **Readability**
   *What elements made the original code confusing or unclear? What did you do to improve it?*

2. **Bug Prevention**
   *How could the original bug have been prevented?*

3. **Boy Scout Rule**
   *How did you apply the Boy Scout Rule in your fix?*

4. **Lessons for the Future**
   *How will this experience change the way you approach unfamiliar or messy code?*
   
5. **Lessons Learned** *Globally, what did you learn from it?*