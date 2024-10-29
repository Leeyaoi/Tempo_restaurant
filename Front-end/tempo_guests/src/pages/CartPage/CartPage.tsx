import React, { useEffect, useState } from "react";
import "./CartPage.scss";
import {
  Button,
  Container,
  FormControl,
  IconButton,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
} from "@mui/material";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { useGlobalStore } from "../../shared/state/globalStore";
import CartItemComponent from "../../components/CartComponents/CartItemComponent/CartItemComponent";
import AddIcon from "@mui/icons-material/Add";
import HorizontalRuleIcon from "@mui/icons-material/HorizontalRule";

const CartPage = () => {
  let { cart, countPrice, countTime, tables, fetchTables } = useGlobalStore();
  const [peopleNumber, setPeopleNumber] = useState(1);

  useEffect(() => {
    fetchTables();
  }, []);

  const [table, setTable] = useState("0");

  cart = Object.fromEntries(
    Object.entries(cart).sort(([a], [b]) => (a > b ? -1 : 1))
  );

  const cartItems = [];

  for (let i in cart) {
    cartItems.push(<CartItemComponent item={cart[i]} key={i} />);
  }

  const handleNumberChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    let newValue = event.target.value as unknown as number;
    if (Number.isInteger(newValue)) {
      if (newValue < 0) {
        newValue = 0;
      }
      setPeopleNumber(newValue);
    }
  };

  const handleTableChange = (event: SelectChangeEvent) => {
    setTable(event.target.value);
  };

  return (
    <Container className="Container">
      <Header />
      <div id="content">
        <div id="cart">
          <p>Корзина</p>
          {cartItems}
          <p id="cart_full_price">Итого: {countPrice()}p</p>
          <div id="people_num">
            <p>Количество людей:</p>
            <div>
              <IconButton
                id="button"
                onClick={() => {
                  let newValue = peopleNumber - 1;
                  if (newValue < 0) {
                    newValue = 0;
                  }
                  setPeopleNumber(newValue);
                }}
              >
                <HorizontalRuleIcon />
              </IconButton>
              <TextField
                type="number"
                className="text-input "
                id="cartNum"
                variant="outlined"
                value={peopleNumber}
                onChange={handleNumberChange}
              />
              <IconButton
                id="button"
                onClick={() => {
                  let newValue = peopleNumber + 1;
                  if (newValue < 0) {
                    newValue = 0;
                  }
                  setPeopleNumber(newValue);
                }}
              >
                <AddIcon />
              </IconButton>
            </div>
          </div>
          <p id="cart_full_time">
            Примерное время готовности заказа: {countTime()}
          </p>
          <div id="cart_table_select">
            <p>Стол:</p>
            <FormControl fullWidth>
              <Select
                className="text-input"
                value={table}
                label="Age"
                onChange={handleTableChange}
              >
                {tables.map((value, i) => {
                  return (
                    <MenuItem
                      key={value.id}
                      value={`${i}`}
                    >{`Стол №${value.number} на ${value.max_people} человек`}</MenuItem>
                  );
                })}
              </Select>
            </FormControl>
          </div>
          <Button id="button" variant="contained">
            Оформить заказ
          </Button>
        </div>
      </div>
      <Footer />
    </Container>
  );
};

export default CartPage;
