import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, MenuItem, Select, TextField } from '@mui/material';
import { SelectChangeEvent } from '@mui/material';
import DrinkDataGrid from './DrinkDataGrid';
import DrinkType from '../../shared/types/drink';
import { useGlobalStore } from '../../shared/state/globalStore';
import CategoryType from '../../shared/types/category';

const DrinkComponent = () => {
    const { Drink, fetchDrink, deleteDrink, updateDrink, createDrink } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [editOpen, setEditOpen] = useState(false);
    const [newDrink, setNewDrink] = useState({} as DrinkType);
    const [selectedDrink, setSelectedDrink] = useState<DrinkType | null>(null);
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);
    const { Category } = useGlobalStore();

    useEffect(() => {
        fetchDrink(page, limit);
    }, [page, limit, open, editOpen]);

    const handleDelete = (id: string) => {
        deleteDrink(id);
    };

    const handleOpenEditDialog = (Drink: {
        id: string; name?: string; approx_time?: number;
        price?: string;
    }) => {
        setSelectedDrink({
            id: Drink.id,
            name: Drink.name ?? '',
            price: Drink.price ?? '',
            category: {} as CategoryType,
            categoryId: ""
        });
        setEditOpen(true);
    };

    const handleCloseEdit = () => {
        setSelectedDrink({
            id: '',
            name: '',
            price: '',
            category: {} as CategoryType,
            categoryId: ""
        });
        setEditOpen(false);
    };

    const handleEditSave = () => {
        if (selectedDrink && selectedDrink.id) {
            updateDrink(selectedDrink.id, selectedDrink);
            handleCloseEdit();
        } else {
            alert("Все поля должны быть заполнены!");
        }
    };

    const handleCreate = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
        setNewDrink({} as DrinkType);
    };

    const handleSave = () => {
        createDrink(newDrink);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    const handleCategoryChange = (event: SelectChangeEvent) => {
        setNewDrink({ ...newDrink, categoryId: event.target.value })
    };

    const renderCategory = () => {
        const items: any[] = [];
        for (let i in Category.items) {
            let value = Category.items[i];
            if (value == null) {
                continue;
            }
            items.push(
                <MenuItem
                    key={`${value.id}`}
                    value={value.id}
                >{`${value.name}`}</MenuItem>
            )
        }
        return items;
    }

    return (
        <>
            <div style={{ marginTop: '1rem', marginBottom: '0.5rem', textAlign: 'center' }}>
                <Button
                    id="add"
                    variant="contained"
                    style={{ backgroundColor: '#FFA500', color: '#fff' }}
                    onClick={handleCreate}
                >
                    Добавить
                </Button>
            </div>
            <DrinkDataGrid
                Drink={Drink}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
                handleDelete={handleDelete}
            />

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать напиток</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Название"
                        type="name"
                        fullWidth
                        value={newDrink.name}
                        onChange={(e) => setNewDrink({ ...newDrink, name: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Цена"
                        type="price"
                        fullWidth
                        value={newDrink.price}
                        onChange={(e) => setNewDrink({ ...newDrink, price: e.target.value })}
                    />
                    <FormControl fullWidth variant="standard">
                        <Select
                            className="text-input"
                            value={newDrink.categoryId ?? ""}
                            onChange={handleCategoryChange}
                        >
                            {renderCategory()}
                        </Select>
                    </FormControl>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>
        </>
    );
};

export default DrinkComponent;