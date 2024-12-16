import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, MenuItem, Select, TextField } from '@mui/material';
import { SelectChangeEvent } from '@mui/material';
import IngredientDataGrid from './IngredientDataGrid';
import IngredientType from '../../shared/types/ingredient';
import { useGlobalStore } from '../../shared/state/globalStore';

const IngredientComponent = () => {
    const { Ingredient, fetchIngredient, deleteIngredient, updateIngredient, createIngredient } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [editOpen, setEditOpen] = useState(false);
    const [newIngredient, setNewIngredient] = useState({} as IngredientType);
    const [selectedIngredient, setSelectedIngredient] = useState<IngredientType | null>(null);
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);

    useEffect(() => {
        fetchIngredient(page, limit);
    }, [page, limit, open, editOpen]);

    const handleDelete = (id: string) => {
        deleteIngredient(id);
    };

    const handleOpenEditDialog = (Ingredient: {
        id: string; name?: string; in_stock?: number;
    }) => {
        setSelectedIngredient({
            id: Ingredient.id,
            name: Ingredient.name ?? '',
            in_stock: Ingredient.in_stock ?? 0,
        });
        setEditOpen(true);
    };

    const handleCloseEdit = () => {
        setSelectedIngredient({
            id: '',
            name: '',
            in_stock: 0,
        });
        setEditOpen(false);
    };

    const handleEditSave = () => {
        if (selectedIngredient && selectedIngredient.id) {
            updateIngredient(selectedIngredient.id, selectedIngredient);
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
        setNewIngredient({} as IngredientType);
    };

    const handleSave = () => {
        createIngredient(newIngredient);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    const handleCategoryChange = (event: SelectChangeEvent) => {
        setNewIngredient({ ...newIngredient, name: event.target.value })
    };

    const renderCategory = () => {
        const items: any[] = [];
        for (let i in name) {
            let value = name.items[i];
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
            <IngredientDataGrid
                Ingredient={Ingredient}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
                handleDelete={handleDelete}
            />

            <FormControl fullWidth variant="standard">
                <Select
                    className="text-input"
                    value={newIngredient.name ?? ""}
                    onChange={handleCategoryChange}
                >
                    {renderCategory()}
                </Select>
            </FormControl>

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать ингредиент</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Название"
                        type="name"
                        fullWidth
                        value={newIngredient.name}
                        onChange={(e) => setNewIngredient({ ...newIngredient, name: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="В наличии"
                        type="in_stock"
                        fullWidth
                        value={newIngredient.in_stock}
                        onChange={(e) => setNewIngredient({ ...newIngredient, in_stock: Number(e.target.value) })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>
        </>
    );
};

export default IngredientComponent;