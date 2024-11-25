import React from 'react'
import WaiterComponent from '../../components/WaiterDataGrid/WaiterComponent';
import CookComponent from '../../components/CookDataGrid/CookComponent';

const MainModule = ({ selectedIndex }: { selectedIndex: number }) => {
    if (selectedIndex == 1) {
        return <CookComponent />;
    }
    if (selectedIndex == 2) {
        return <WaiterComponent/>;
    }
    if (selectedIndex == 3) {
        return <p>Блюда</p>
    }
    if (selectedIndex == 4) {
        return <p>Ингредиенты</p>
    }
    if (selectedIndex == 5) {
        return <p>Напитки</p>
    }
    if (selectedIndex == 6) {
        return <p>Ингредиенты</p>
    }
}

export default MainModule