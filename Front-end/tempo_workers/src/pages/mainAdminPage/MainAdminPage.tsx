import * as React from 'react';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Collapse from '@mui/material/Collapse';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import "./mainAdminPage.scss";
import PeopleIcon from '@mui/icons-material/People';
import LunchDiningIcon from '@mui/icons-material/LunchDining';
import CoffeeRoundedIcon from '@mui/icons-material/CoffeeRounded';
import KitchenRoundedIcon from '@mui/icons-material/KitchenRounded';
import { useGlobalStore } from '../../shared/state/globalStore';
import MainModule from '../../modules/mainModule/MainModule';
import EmployeeType from '../../shared/types/employee';

export default function NestedList() {
  const { employees, fetchEmployees } = useGlobalStore();

  const [limit, setLimit] = React.useState(5);
  const [page, setPage] = React.useState(1);

  React.useEffect(() => {
    fetchEmployees(page, limit);
  }, [page, limit]);

  const [open, setOpen] = React.useState(false);

  const handleClick = () => {
    setOpen(!open);
  };

  const [selectedIndex, setSelectedIndex] = React.useState(1);

  const handleListItemClick = (
    event: React.MouseEvent<HTMLDivElement, MouseEvent>,
    index: number,
  ) => {
    setSelectedIndex(index);
  };

  return (
    <div className="Container">
      <Header />
      <div id="content">
        <List sx={{ width: '50%', maxWidth: 360 }}>
          <ListItemButton selected={selectedIndex === 1}
            onClick={(event) => handleListItemClick(event, 1)}>
            <ListItemIcon>
              <PeopleIcon />
            </ListItemIcon>
            <ListItemText primary="Сотрудники" />
          </ListItemButton>

          <ListItemButton onClick={handleClick}>
            <ListItemIcon>
              <LunchDiningIcon />
            </ListItemIcon>
            <ListItemText primary="Блюда" />
            {open ? <ExpandLess /> : <ExpandMore />}
          </ListItemButton>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <List component="div" disablePadding>
              <ListItemButton sx={{ pl: 4 }} selected={selectedIndex === 0}
                onClick={(event) => handleListItemClick(event, 0)}>
                <ListItemIcon>
                </ListItemIcon>
                <ListItemText primary="Блюда" />
              </ListItemButton>
              <ListItemButton sx={{ pl: 4 }} selected={selectedIndex === 2}
                onClick={(event) => handleListItemClick(event, 2)}>
                <ListItemIcon>
                </ListItemIcon>
                <ListItemText primary="Ингредиенты" />
              </ListItemButton>
            </List>
          </Collapse>

          <ListItemButton selected={selectedIndex === 3}
            onClick={(event) => handleListItemClick(event, 3)}>
            <ListItemIcon>
              <CoffeeRoundedIcon />
            </ListItemIcon>
            <ListItemText primary="Напитки" />
          </ListItemButton>

          <ListItemButton selected={selectedIndex === 4}
            onClick={(event) => handleListItemClick(event, 4)}>
            <ListItemIcon>
              <KitchenRoundedIcon />
            </ListItemIcon>
            <ListItemText primary="Ингредиенты" />
          </ListItemButton>
        </List>

        <div style={{ width: '90%' }}>
          <MainModule selectedIndex={selectedIndex} />
        </div>

      </div>
      <Footer />
    </div>
  );
}