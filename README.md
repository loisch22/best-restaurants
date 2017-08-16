# _Best Restaurant_

#### _Users can add and search restaurants based on cuisine and location, August 16, 2017_

#### By _**Lois Choi & Michael Woldemedihin**_

## Description

_This program is for an Epicodus project. A user can add a restaurant by the type of cuisine. Users can also add the location and search by cuisine, restaurant, or location._

| Behavior  | Input  | Output  |
|---|---|---|
| 1. User can add `cuisine` and clicks `Add` button, the cuisine will be added and the user should be redirected to the `list of cuisines` view. | type `mexican` + click `Add` |   List of cuisines: / `mexican` |
| 2. While the user is on the `list of cuisines` view, user can add another cuisine or go back to `Home`. | > click `Add` or <br> > click `Home` |> redirected to `Add cuisine` form <br> > redirected to `Home` page|
| 3. User can add `restaurant` and clicks `Add` button, the restaurant will be added and the user should be redirected to the `list of restaurants` view. | type `chipotle` + click `Add` |   List of restaurants: / `chipotle` |
| 4. While the user is on the `list of restaurants` view, user can add another restaurant or go back to `Home`. | > click `Add` or <br> > click `Home` |> redirected to `Add restaurant` form <br> > redirected to `Home` page|
| 5. While the user is in the `List of Cuisines` view, user can click a `cuisine` and view all the restaurants for that cuisine. | > Click `mexican` |  View: `Chipotle` |
| 6. User can click the `restaurant` to view the restaurant details. | > Click `Chipotle` |  View: <br> -Chipotle<br> -location<br> -cuisine type |
| 7. From the `List of Restaurants` view, user can select a restaurant and view its details| > click `Chipotle` | View: <br> -Chipotle<br> -location<br> -cuisine type|
| 8. From the `List of Restaurants` view, user can delete all restaurants from the list. An alert will show that lets users confirm all deletion or cancel. If the user confirms - user will be redirected to `CONFIRMATION` view (all cuisines will be cleared). If user cancels - User will stay on the `List of Restaurants` view | > Input 1: Confirm delete all <br> > Input 2: Cancel | > Output 1: `Confirmation` Page with button to go `HOME` or `ADD NEW RESTAURANTS` <br> > Output 2: `List of Restaurants` Page|
| 9. From the `List of Cuisines` view, user can delete all cuisines from the list. An alert will show that lets users confirm all deletion (Warning: All restaurants for this cuisine will also be deleted) or cancel. If the user confirms - user will be redirected to `CONFIRMATION` view (all cuisines will be cleared). If user cancels - User will stay on the `List of Cuisines` view | > Input 1: Confirm delete all <br> > Input 2: Cancel | > Output 1: `Confirmation` Page with button to go `HOME` or `ADD NEW CUISINE` <br> > Output 2: `List of Cuisines` Page|
| 10. User can delete a specific restaurant from the `List of All Restaurants` or the `List of Restaurants` for a specific cuisine | > Click `Delete` | View: List of Restaurants without the deleted restaurant |
| 11. User can click `Delete` to delete a specific cuisine from the `List of All Cuisines`. An alert will show: "WARNING: Deleting this cuisine will delete all the restaurants for this cuisine." If user confirms: The cuisine will be deleted from the `List of Cuisines` and the `List of Cuisines` will show. If cancel: User will remain on the `List of Cuisines` view | > Click `Delete` <br> - Show WARNING <br> > Input 1: `CONFIRM` <br> > Input 2: `CANCEL` | > Output 1: The NEW list without the deleted cuisine will return <br> > Output 2: Same `List of Cuisines` view |
| 12. User can delete a specific restaurant from the `Restaurant Details` page by clicking `Delete` link | > Click `Delete` | View: `Cuisine Restaurant List` without the deleted restaurant |
| 13. User can update a specific cuisine by clicking `Update`| > Click `Update` | Return: `Cuisine Form` to update Cuisine Name |
| 14. User can update a specific restaurant by clicking `Update`| > Click `Update` | Return: `Restaurant Form` to update Cuisine Name |
| 15. User can search a specific `cuisine` and view the list of restaurants for that cuisine | Search: "Mexican" | View: `Mexican Restaurants` list |
| 16. User can search a specific `restaurant` and view its restaurant details | Search: "Chipotle" | View: `Chipotle Details` page |
| 17. If there is no match for the search term, display an alert message "We could not find a match for your search term. Would you like to add it?" User can click `Add` or `Cancel` | > Input 1: `Add` <br> > Input 2: `Cancel`| > Output 1: `Add form` (restaurant or cuisine) <br> > Output 2: Remain `HOME` page  |

## Wishilist:
Rating/Review, cuisine/restaurant count, price range ($ - $$ - $$$),

## Setup/Installation Requirements

* _Clone repository_

## Known Bugs

_When running dotnet run and then opening http://localhost:5000 in browser, HTML content does not show. Blue background does show._

## Technologies Used

_HTML, CSS, C#, .NET_

### License

*MIT License*

Copyright (c) 2017 **_Lois Choi & Michael Woldemedihin_**
