# TaxCollectorApp
A coding assignment to call to the TaxJar api

Victoria Redenbaugh

This application is meant to simulate a check out process (but with manually entering an order amount). There are 3 views and view models -> order placer, shipping, and order summary

Application Notes:
1. In hopes of moving forward in the process, I wanted to get some practice with Realm. Would love some feedback on best practices.
2. For sake of following prompt, the "order" amount is a manual input. Must enter a value for the order above 0.
3. Shipping with radio buttons is hard coded with values again for sake of following prompt.
4. Shipping address must be in US.
5. Added a mock nexus address for each state just to get the Tax Jar api to return some tax on the order. States must be one of the 50 states.
6. Button to "Get Rates for Location" simply is just to address the GetRates api call.
7. Would love feedback on best practices for unit testing.
