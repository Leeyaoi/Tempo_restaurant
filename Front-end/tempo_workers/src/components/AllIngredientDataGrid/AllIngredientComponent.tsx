import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, MenuItem, Select, TextField } from '@mui/material';
import { SelectChangeEvent } from '@mui/material';
import AllIngredientDataGrid from './AllIngredientDataGrid';
import IngredientType from '../../shared/types/ingredient';
import { useGlobalStore } from '../../shared/state/globalStore';

const AllIngredientComponent = () => {
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
            in_stock: 0
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
            <AllIngredientDataGrid
                Ingredient={Ingredient}
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

export default AllIngredientComponent;