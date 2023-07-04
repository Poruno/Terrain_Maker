# 2 Main Architectures: 
 - Game: Entity - Component - System Architecture
 - UI: HTML + Stylesheet Architecture
 
# GUIDE TO UNDERSTANDING THE ENTITY - COMPONENT - SYSTEM
### The biggest rule for this system: Entity strictly only possesses "2" variables:
``` 
int ID;
List<Component> components;
```
Any Data that an entity should have should be made as a component i.e. Movement functions, Logic Functions, or just raw data
Any interaction between Entities should be handled by A system. 

Perceived Events:
- Entity will ask permission to system that an "event" happened and "assigned system" will handle the logic between the 2 entities. i.e. "is the door locked?" asking the door
- Entity will behave as it should be as an individual, The world/system will fix this behavior i.e. going through doors, CollisionSystem will see 2 Entities overlapping each other sending the movable entity back to it's latest position or allowing the Entity to touch the wall.

# GUIDE TO UNDERSTANDING THE UI SYSTEM

### It is formatted to feel almost the same as if you're programming HTML and CSS

There will be an Element Tree much like HTML.

## UIElement.cs
Contains all of the functions, and values to make a page

This contains a Stylesheet Dictionary. Much like CSS it's usage will be:
```
stylesheet["x"] = "33";
```

### UIElement positioning
UIElement positioning is stackable to it's ancestor nodes i.e. 
```
root -> child1 -> child2
stylesheet["x"] = 0 -> stylesheet["x"] = 20 -> stylesheet["x"] = 30
```
result
```
root -> child1 -> child2
x = 0 -> x = 20 -> x = 50
```

## IPages.cs and UI.cs
1) UI contains all of the pages
2) Pages contains all of the UIElements

## Stylesheet Guide
### for positioning horizontally and vertically, stacks with Ancestor styleshee positioning
```
stylesheet["x"]
stylesheet["y"]
```
I would eventually change it to this:
```
stylesheet["left"]
stylesheet["right"]
stylesheet["bottom"]
stylesheet["top"]
```
~~But it's taking me too long to figure it out right now~~
### Changing the background color:
```
stylesheet["background-color"] = "#00000000";
```
### Changing the text color
```
stylesheet["color"] = "#00000000";
```
