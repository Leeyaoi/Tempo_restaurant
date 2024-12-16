import React, { useEffect, useState } from "react";
import {
    Button,
    FormControl,
    MenuItem,
    Select,
    SelectChangeEvent,
    Dialog,
    DialogTitle,
    DialogContent,
    TextField,
    DialogActions,
} from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import KeyboardDoubleArrowLeftIcon from "@mui/icons-material/KeyboardDoubleArrowLeft";
import KeyboardArrowLeftIcon from "@mui/icons-material/KeyboardArrowLeft";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardDoubleArrowRightIcon from "@mui/icons-material/KeyboardDoubleArrowRight";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import DrinkType from "../../shared/types/drink";
import PaginatedType from "../../shared/types/paginatedModel";
import { useGlobalStore } from "../../shared/state/globalStore";

interface Props {
    Drink: PaginatedType<DrinkType>;
    limit: number;
    handleLimitChange: (event: SelectChangeEvent) => void;
    page: number;
    setPage: (value: number) => void;
    handleEdit: (id: string, data: Partial<DrinkType>) => void;
    handleDelete: (id: string) => void;
}

const DrinkDataGrid = ({
    Drink,
    limit,
    handleLimitChange,
    page,
    setPage,
    handleEdit,
    handleDelete,
}: Props) => {
    const { updateDrink, fetchCategory, Category } = useGlobalStore();
    const [openEdit, setOpenEdit] = useState(false);
    const [openDelete, setOpenDelete] = useState(false);
    const [newDrink, setNewDrink] = useState<DrinkType>({} as DrinkType);
    const [editId, setEditId] = useState<string | null>(null);
    const [deleteId, setDeleteId] = useState<string | null>(null);

    useEffect(() => { fetchCategory() },
        []
    )

    const handleOpenEditDialog = (id: string, data: DrinkType) => {
        setEditId(id);
        setNewDrink(data);
        setOpenEdit(true);
    };

    const handleCloseEdit = () => {
        setOpenEdit(false);
        setEditId(null);
        setNewDrink({} as DrinkType);
    };

    const handleSave = async () => {
        console.log(editId);
        if (editId) {
            await updateDrink(editId, newDrink);
        }
        handleCloseEdit();
    };

    const handleOpenDeleteDialog = (id: string) => {
        setDeleteId(id);
        setOpenDelete(true);
    };

    const handleCloseDelete = () => {
        setOpenDelete(false);
        setDeleteId(null);
    };

    const handleConfirmDelete = () => {
        if (deleteId) {
            handleDelete(deleteId);
        }
        handleCloseDelete();
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

    const columns: GridColDef<DrinkType[][number]>[] = [
        {
            field: "name",
            headerName: "Имя",
            width: 180,
            editable: false,
        },
        {
            field: "price",
            headerName: "Цена",
            width: 180,
            editable: false,
        },
        {
            field: "category",
            headerName: "Категория",
            renderCell: (params) => { if (params.row.category) return params.row.category.name },
            width: 180,
            editable: false,
        },
        {
            field: "actions",
            headerName: "Действия",
            width: 190,
            renderCell: (params) => (
                <>
                    <Button
                        style={{ marginRight: "0.5rem" }}
                        color="success"
                        variant="contained"
                        id="actionButton"
                        onClick={() =>
                            handleOpenEditDialog(params.id as string, params.row)
                        }
                    >
                        <EditIcon />
                    </Button>
                    <Button
                        color="error"
                        onClick={() => handleOpenDeleteDialog(params.id as string)}
                        variant="contained"
                        id="actionButton"
                    >
                        <DeleteIcon />
                    </Button>
                </>
            ),
        },
    ];

    return (
        <>
            <div>
                <DataGrid
                    rows={Drink ? Drink.items : []}
                    columns={columns}
                    disableRowSelectionOnClick
                    hideFooter={true}
                />
            </div>
            <div id="pagination-size-control">
                <p>Размер страницы:</p>
                <FormControl variant="standard">
                    <Select
                        className="text-input"
                        value={limit.toString()}
                        onChange={handleLimitChange}
                    >
                        <MenuItem key={5} value={5}>
                            5
                        </MenuItem>
                        <MenuItem key={10} value={10}>
                            10
                        </MenuItem>
                    </Select>
                </FormControl>
                <p id="total_data">Всего записей: {Drink ? Drink.total : 0}</p>
                <div id="pagination-control">
                    <Button variant="contained" onClick={() => setPage(1)}>
                        <KeyboardDoubleArrowLeftIcon />
                    </Button>
                    <Button
                        variant="contained"
                        onClick={() => setPage(Math.max(1, page - 1))}
                    >
                        <KeyboardArrowLeftIcon />
                    </Button>
                    <p>
                        {Drink ? Drink.page : 0} .. {Drink ? Drink.pageCount : 0}
                    </p>
                    <Button
                        variant="contained"
                        onClick={() => setPage(Math.min(Drink.pageCount, page + 1))}
                    >
                        <KeyboardArrowRightIcon />
                    </Button>
                    <Button variant="contained" onClick={() => setPage(Drink.pageCount)}>
                        <KeyboardDoubleArrowRightIcon />
                    </Button>
                </div>
            </div>

            <Dialog open={openEdit} onClose={handleCloseEdit}>
                <DialogTitle>Редактировать блюдо</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Имя"
                        fullWidth
                        value={newDrink.name}
                        onChange={(e) =>
                            setNewDrink({ ...newDrink, name: e.target.value })
                        }
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Цена"
                        fullWidth
                        value={newDrink.price}
                        onChange={(e) =>
                            setNewDrink({ ...newDrink, price: e.target.value })
                        }
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
                    <Button onClick={handleCloseEdit}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>

            <Dialog open={openDelete} onClose={handleCloseDelete}>
                <DialogTitle>Подтверждение удаления</DialogTitle>
                <DialogContent>
                    <p>Вы уверены, что хотите удалить этот напиток?</p>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDelete}>Отмена</Button>
                    <Button color="error" onClick={handleConfirmDelete}>
                        Удалить
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};

export default DrinkDataGrid;
