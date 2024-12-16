import React from 'react'
import WaiterComponent from '../../components/WaiterDataGrid/WaiterComponent';
import CookComponent from '../../components/CookDataGrid/CookComponent';
import DishesComponent from '../../components/DishesdataGrid/DishesComponent';
import DrinkComponent from '../../components/DrinksDataGrid/DrinkComponent';
import AllIngredientComponent from '../../components/AllIngredientDataGrid/AllIngredientComponent';
import IngredientComponent from '../../components/IngredientDaraGrid/IngredientComponent';

const MainModule = ({ selectedIndex }: { selectedIndex: number }) => {
    if (selectedIndex == 1) {
        return <CookComponent />;
    }
    if (selectedIndex == 2) {
        return <WaiterComponent/>;
    }
    if (selectedIndex == 3) {
        return <DishesComponent/>
    }
    if (selectedIndex == 4) {
        return <IngredientComponent/>
    }
    if (selectedIndex == 5) {
        return <DrinkComponent/>
    }
    if (selectedIndex == 6) {
        return <AllIngredientComponent/>
    }
}

export default MainModule