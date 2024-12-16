import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, MenuItem, Select, TextField } from '@mui/material';
import { SelectChangeEvent } from '@mui/material';
import DishesDataGrid from './DishesDataGrid';
import DishesType from '../../shared/types/dishes';
import { useGlobalStore } from '../../shared/state/globalStore';
import CategoryType from '../../shared/types/category';

const DishesComponent = () => {
    const { Dishes, fetchDishes, deleteDishes, updateDishes, createDishes } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [editOpen, setEditOpen] = useState(false);
    const [newDishes, setNewDishes] = useState({} as DishesType);
    const [selectedDishes, setSelectedDishes] = useState<DishesType| null>(null);
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);
    const { Category } = useGlobalStore();

    useEffect(() => {
        fetchDishes(page, limit);
    }, [page, limit, open, editOpen]);

    const handleDelete = (id: string) => {
        deleteDishes(id);
    };

    const handleOpenEditDialog = (dishes: {
        id: string; name?: string; approx_time?: number;
        price?: string;
    }) => {
        setSelectedDishes({
            id: dishes.id,
            name: dishes.name ?? '',
            approx_time: dishes.approx_time ?? 0,
            price: dishes.price ?? '',
            category: {} as CategoryType,
            categoryId: ""
        });
        setEditOpen(true);
    };

    const handleCloseEdit = () => {
        setSelectedDishes({
            id: '',
            name: '',
            approx_time: 0,
            price: '',
            category: {} as CategoryType,
            categoryId: ""
        });
        setEditOpen(false);
    };

    const handleEditSave = () => {
        if (selectedDishes && selectedDishes.id) {
            updateDishes(selectedDishes.id, selectedDishes);
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
        setNewDishes({} as DishesType);
    };

    const handleSave = () => {
        createDishes(newDishes);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    const handleCategoryChange = (event: SelectChangeEvent) => {
        setNewDishes({ ...newDishes, categoryId: event.target.value })
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
            <DishesDataGrid
                dishes={Dishes}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
                handleDelete={handleDelete}
            />

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать блюдо</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Название"
                        type="name"
                        fullWidth
                        value={newDishes.name}
                        onChange={(e) => setNewDishes({ ...newDishes, name: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Приблизительное время"
                        type="approx_time"
                        fullWidth
                        value={newDishes.approx_time}
                        onChange={(e) => setNewDishes({ ...newDishes, approx_time: Number(e.target.value) })}
                    />
                    <TextField
                        margin="dense"
                        label="Цена"
                        type="price"
                        fullWidth
                        value={newDishes.price}
                        onChange={(e) => setNewDishes({ ...newDishes, price: e.target.value })}
                    />
                    <FormControl fullWidth variant="standard">
                        <Select
                            className="text-input"
                            value={newDishes.categoryId ?? ""}
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

export default DishesComponent;