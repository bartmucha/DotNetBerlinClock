
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: Seconds are even
When the time is "00:00:20"
Then seconds should look like
"""
Y
"""

Scenario: Hours devides by 4 without reminder
When the time is "05:00:00"
Then hours should look like
"""
ROOO
OOOO
"""

Scenario: Hours devides by 4 with reminder
When the time is "17:00:00"
Then hours should look like
"""
RRRO
RROO
"""

Scenario: Minutes devides by 5 without reminder
When the time is "17:05:00"
Then minutes should look like
"""
YOOOOOOOOOO
OOOO
"""

Scenario: Minutes devides by 5 with reminder
When the time is "17:23:00"
Then minutes should look like
"""
YYRYOOOOOOO
YYYO
"""

Scenario: Minutes devides by 15 without reminder
When the time is "17:30:00"
Then minutes should look like
"""
YYRYYROOOOO
OOOO
"""

Scenario: Time invalid
When the time is "25:00:00"
Then throw FormatException