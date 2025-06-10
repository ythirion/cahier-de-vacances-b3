# Week 7 – *Rewrite the Rule Matrix*
The Matrix is mutating.

Agent Smith has changed tactics—**validation rules are no longer fixed** in the code. They’re fluid, shifting like the code streams around them.

Hardcoding won’t save you now.

Your new directive:

- **Build a dynamic password validation core** backed by a decentralized database node.
- **Log every validation attempt**—encrypted, trace-proof, unalterable.

![Week 7 - Rewrite the Rule Matrix](img/week07.webp)

You’re not just fighting the system.
**You are rebuilding the system.**

## Mission Objectives

### Objective 1: Extract Rules into the Rule Matrix

Move each validation rule into a **SQLite database**:

* Each rule must contain:

  * a unique `id`
  * a `description`
  * an `active` flag

Only rules marked `active: true` are enforced.

> Zion must be able to toggle rules at runtime. The Matrix adapts—we must adapt faster.

### Objective 2: Refactor the API to Load Rules from the Matrix

In your `POST /api/password-check` endpoint:

* Load all `active` rules from the database
* Evaluate the password against each one
* Return the **validity per rule** and a global `isValid` state

> You’re now building a **self-evolving validator**. No redeploy. No fear.

### Objective 3: Log Every Password Attempt

Every simulation must be logged:

* Store:
  * a **secure hash** of the password (e.g. SHA-256)
  * the evaluation result
  * a timestamp

Never store raw passwords. Even machines in `Zion` have standards.

## 🧰 Zion Stack Upgrade

* **SQLite** – lightweight, stealthy, embeddable
* Backend logic remains in `/api/password-check`
* Frontend stays untouched

## 🧑‍💻 Your Mission

1. **Create a rule-driven validator** using SQLite
2. **Fetch rules dynamically**
3. **Log all attempts** with strong security measures
4. **Keep your breach UI as-is**

## ☕ Reflect
After rewriting the rule core, take a moment to consider:

1. **What benefits does this dynamic rule system bring over hardcoded logic?**
2. **How did moving logic to the database impact testability or flexibility?**
3. **What challenges arise in keeping track of system behavior when rules are mutable?**
4. **How would you scale this architecture if new rule types required more complex logic?**