import React from 'react'
import EmployeesComponent from '../../components/EmployeesComponent';

const MainModule = ({ selectedIndex }: { selectedIndex: number }) => {
    if (selectedIndex == 1) {
        return <EmployeesComponent />;
    }
    if (selectedIndex == 0) {
        return <p>Dishes</p>;
    }
    if (selectedIndex == 2) {
        return <p>Ingredients</p>
    }
    if (selectedIndex == 3) {
        return <p>Drinks</p>
    }
    if (selectedIndex == 4) {
        return <p>Ingredient</p>
    }
}

export default MainModule