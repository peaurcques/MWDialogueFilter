# Name 
Morrowind Dialogue Filter

# Purpose
Provide Modders with a way to filter their dialogue using a wide array of test scenarios outside the game. 
This should make dialogue modding easier and more systematic and help avoid unexpected bugs.
Allow the Modder to easily create new Temporary NPCs/PCs for use in testing with either a single line of code or by filling out a UI form.

# TO DO
TODO: incorporate or utilize G7's esp->json RUST program to load data in from your mods. This will allow for cross-mod testing and data 
TODO: Make a UI from which you can set the variables for a test and run through the entire dialogue until it terminates
TODO: Add Inventory filtering
TODO: Add Cell Filtering
TODO: Load data from UESP website or directly from Morrowind.esm via G7's esp->json
TODO: Add a How-To Guide

# Changelog
21-6-2023
Version 0.0.1
    First commit. Dialogue Filter Testing using CMD_Line or XUnit Unit Tests. 
    Just set the conditions for each test, and program runs through each scenario and gives a pass/fail based off returned Response
    Filters based off NPC/PC attributes, Choices, & Journal Entries
    Allows for the Dynamic Creation of temporary NPCs/PCs to easily simulate a wide array of scenarios
