import * as React from 'react';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Collapse from '@mui/material/Collapse';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import SendIcon from '@mui/icons-material/Send';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import StarBorder from '@mui/icons-material/StarBorder';
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import "./mainAdminPage.scss";

export default function NestedList() {
  const [open, setOpen] = React.useState(false);

  const handleClick = () => {
    setOpen(!open);
  };

  return (
    <div className="Container">
      <Header />
      <div id="content">
        <List sx={{ width: '50%', maxWidth: 360 }}>
          <ListItemButton>
            <ListItemIcon>
            </ListItemIcon>
            <ListItemText primary="Сотрудники" />
          </ListItemButton>

          <ListItemButton onClick={handleClick}>
            <ListItemIcon>
            </ListItemIcon>
            <ListItemText primary="Блюда" />
            {open ? <ExpandLess /> : <ExpandMore />}
          </ListItemButton>

          <Collapse in={open} timeout="auto" unmountOnExit>
            <List component="div" disablePadding>
              <ListItemButton sx={{ pl: 4 }}>
                <ListItemIcon>
                </ListItemIcon>
                <ListItemText primary="Ингредиенты" />
              </ListItemButton>
            </List>
          </Collapse>

          <ListItemButton>
            <ListItemIcon>
            </ListItemIcon>
            <ListItemText primary="Напитки" />
          </ListItemButton>

          <ListItemButton>
            <ListItemIcon>
            </ListItemIcon>
            <ListItemText primary="Ингредиенты" />
          </ListItemButton>
        </List>
      </div>
      <Footer />
    </div>
  );
}