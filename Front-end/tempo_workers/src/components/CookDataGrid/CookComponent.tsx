import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, MenuItem, Select, TextField } from '@mui/material';
import { useGlobalStore } from '../../shared/state/globalStore';
import { SelectChangeEvent } from '@mui/material';
import CookDataGrid from './CookDataGrid';
import CookType from '../../shared/types/cook';

const EmployeesComponent = () => {
    const { cooks, fetchCooks, deleteCook, updateCook, createCook } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [editOpen, setEditOpen] = useState(false);
    const [newCook, setNewCook] = useState({} as CookType);
    const [selectedCook, setSelectedCook] = useState<{
        id: string;
        name: string;
        surname: string;
        login: string;
        password: string;
    } | null>(null);
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);
    const { Category } = useGlobalStore();

    useEffect(() => {
        fetchCooks(page, limit);
    }, [page, limit, open, editOpen]);

    const handleDelete = (id: string) => {
        deleteCook(id);
    };

    const handleOpenEditDialog = (cook: {
        id: string; name?: string; surname?: string;
        login?: string; password?: string;
    }) => {
        setSelectedCook({
            id: cook.id,
            name: cook.name ?? '',
            surname: cook.surname ?? '',
            login: cook.login ?? '',
            password: cook.password ?? '',
        });
        setEditOpen(true);
    };

    const handleCloseEdit = () => {
        setSelectedCook({
            id: '',
            name: '',
            surname: '',
            login: '',
            password: '',
        });
        setEditOpen(false);
    };

    const handleEditSave = () => {
        if (selectedCook) {
            updateCook(String(selectedCook.id), selectedCook);
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
        setNewCook({} as CookType);
    };

    const handleSave = () => {
        createCook(newCook);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    const handleCategoryChange = (event: SelectChangeEvent) => {
        setNewCook({ ...newCook, categoryId: event.target.value })
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
            <CookDataGrid
                cook={cooks}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
                handleDelete={handleDelete}
            />

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать сотрудника</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Имя"
                        type="name"
                        fullWidth
                        value={newCook.name}
                        onChange={(e) => setNewCook({ ...newCook, name: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Фамилия"
                        type="lastName"
                        fullWidth
                        value={newCook.surname}
                        onChange={(e) => setNewCook({ ...newCook, surname: e.target.value })}
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Логин"
                        fullWidth
                        value={newCook.employee ? newCook.employee.login : ""}
                        onChange={(e) => setNewCook({ ...newCook, employee: { ...newCook.employee, login: e.target.value } })}
                    />
                    <TextField
                        margin="dense"
                        label="Пароль"
                        type="password"
                        fullWidth
                        value={newCook.employee ? newCook.employee.password : ""}
                        onChange={(e) => setNewCook({ ...newCook, employee: { ...newCook.employee, password: e.target.value } })}
                    />
                    <FormControl fullWidth variant="standard">
                        <Select
                            className="text-input"
                            value={newCook.categoryId ?? ""}
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

export default EmployeesComponent;