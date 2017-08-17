# _Best Restaurant_

#### _Users can add and search restaurants based on cuisine and location, August 16, 2017_

#### By _**Lois Choi & Michael Woldemedihin**_

## Description

_This program is for an Epicodus project. A user can add a restaurant by the type of cuisine. Users can also add the location and search by cuisine, restaurant, or location._

| Behavior  | Input  | Output  |
|---|---|---|
| 1. User can add `cuisine` and clicks `ADD` button, the cuisine will be added and the user should be redirected to the `list of cuisines` view. | type `mexican` + click `ADD` |   List of cuisines: / `mexican` |
| 2. While the user is on the `list of cuisines` view, user can add another cuisine or go back to `Home`. | > click `ADD` or <br> > click `Home` |> redirected to `Add cuisine` form <br> > redirected to `Home` page|
| 3. User can add `restaurant` and clicks `ADD` button, the restaurant will be added and the user should be redirected to the `list of restaurants` view. | type `chipotle` + click `ADD` |   List of restaurants: / `chipotle` |
| 4. While the user is on the `list of restaurants` view, user can add another restaurant or go back to `Home`. | > click `ADD` or <br> > click `Home` |> redirected to `Add restaurant` form <br> > redirected to `Home` page|
| 5. While the user is in the `List of Cuisines` view, user can click a `cuisine` and view all the restaurants for that cuisine. | > Click `mexican` |  View: `Chipotle` |
| 6. User can click a `restaurant` from the `specific cuisine page` to view the restaurant details. | > Click `Chipotle` |  View: <br> -Chipotle<br> -location<br> -cuisine type |
| 7. From the `List of Restaurants` view, user can select a restaurant and view its details| > click `Chipotle` | View: <br> -Chipotle<br> -location<br> -cuisine type|
| 8. User can`DELETE`ALL restaurants from the `All Restaurants list`. An alert will show that lets users confirm all deletion or cancel. If the user confirms - user will be redirected to `CONFIRMATION` view (all cuisines will be cleared). If user cancels - User will stay on the `List of Restaurants` view | > Input 1: Confirm`DELETE`all <br> > Input 2: Cancel | > Output 1: `Confirmation` Page with button to go `HOME` or `ADD NEW RESTAURANTS` <br> > Output 2: `List of Restaurants` Page|
| 9. User can delete ALL restaurants from a `Specific Cuisine`. An alert will show that lets users confirm all deletion or cancel. If the user confirms - user will be redirected to `CONFIRMATION` view (all cuisines will be cleared). If user cancels - User will stay on the `List of Restaurants` view | > Input 1: Confirm delete all <br> > Input 2: Cancel | > Output 1: `Confirmation` Page with button to go `HOME` or `ADD NEW RESTAURANTS` <br> > Output 2: `List of Restaurants` Page|
| 10. User can`DELETE`ALL cuisines from the `All Cuisines list`. An alert will show that lets users confirm all deletion (Warning: All restaurants for this cuisine will also be `deleted`) or cancel. If the user confirms - user will be redirected to `CONFIRMATION` view (all cuisines will be cleared). If user cancels - User will stay on the `List of Cuisines` view | > Input 1: Confirm`DELETE`all <br> > Input 2: Cancel | > Output 1: `Confirmation` Page with button to go `HOME` or `ADD NEW CUISINE` <br> > Output 2: `List of Cuisines` Page|
| 11. User can `DELETE` a specific restaurant from the `List of All Restaurants` or from the `Specific Cuisine`| > Click `Delete` | View: List of Restaurants without the `deleted` restaurant |
| 12. User can click `Delete` to`DELETE`a specific cuisine from the `List of All Cuisines`. An alert will show: "WARNING: Deleting this cuisine will`DELETE`all the restaurants for this cuisine." If user confirms: The cuisine will be `deleted` from the `List of Cuisines` and the `List of Cuisines` will show. If cancel: User will remain on the `List of Cuisines` view | > Click `Delete` <br> - Show WARNING <br> > Input 1: `CONFIRM` <br> > Input 2: `CANCEL` | > Output 1: The NEW list without the `deleted` cuisine will return <br> > Output 2: Same `List of Cuisines` view |
| 13. User can`DELETE`a specific restaurant from the `Restaurant Details` page by clicking `Delete` link | > Click `Delete` | View: `Cuisine Restaurant List` without the `deleted` restaurant |
| 14. User can `UPDATE` a specific cuisine name by clicking `Update`| > Click `Update` | Return: `Cuisine Form` to `UPDATE` Cuisine Name |
| 15. User can `UPDATE` a specific restaurant by clicking `Update`| > Click `Update` | Return: `Restaurant Form` to `UPDATE` Cuisine Name |
| 15. User can search a specific `cuisine` and view the list of restaurants for that cuisine | Search: "Mexican" | View: `Mexican Restaurants` list |
| 16. User can search a specific `restaurant` and view its restaurant details | Search: "Chipotle" | View: `Chipotle Details` page |
| 17. If there is no match for the search term, display an alert message "We could not find a match for your search term. | > Input: `Cancel`| > Output: Remain `HOME` page  |

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
