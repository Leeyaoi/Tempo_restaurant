import React, { useState } from "react";
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
import IngredientType from "../../shared/types/ingredient";
import PaginatedType from "../../shared/types/paginatedModel";
import { useGlobalStore } from "../../shared/state/globalStore";

interface Props {
    Ingredient: PaginatedType<IngredientType>;
    limit: number;
    handleLimitChange: (event: SelectChangeEvent) => void;
    page: number;
    setPage: (value: number) => void;
    handleEdit: (id: string, data: Partial<IngredientType>) => void;
    handleDelete: (id: string) => void;
}

const IngredientDataGrid = ({
    Ingredient,
    limit,
    handleLimitChange,
    page,
    setPage,
    handleEdit,
    handleDelete,
}: Props) => {
    const { updateIngredient } = useGlobalStore();
    const [openEdit, setOpenEdit] = useState(false);
    const [openDelete, setOpenDelete] = useState(false);
    const [newIngredient, setNewIngredient] = useState<IngredientType>({} as IngredientType);
    const [editId, setEditId] = useState<string | null>(null);
    const [deleteId, setDeleteId] = useState<string | null>(null);

    const handleOpenEditDialog = (id: string, data: IngredientType) => {
        setEditId(id);
        setNewIngredient(data);
        setOpenEdit(true);
    };

    const handleCloseEdit = () => {
        setOpenEdit(false);
        setEditId(null);
        setNewIngredient({} as IngredientType);
    };

    const handleSave = async () => {
        console.log(editId);
        if (editId) {
            await updateIngredient(editId, newIngredient);
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

    const columns: GridColDef<IngredientType[][number]>[] = [
        {
            field: "name",
            headerName: "Имя",
            width: 180,
            editable: false,
        },
        {
            field: "in_stock",
            headerName: "В наличии",
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
                    rows={Ingredient ? Ingredient.items : []}
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
                <p id="total_data">Всего записей: {Ingredient ? Ingredient.total : 0}</p>
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
                        {Ingredient ? Ingredient.page : 0} .. {Ingredient ? Ingredient.pageCount : 0}
                    </p>
                    <Button
                        variant="contained"
                        onClick={() => setPage(Math.min(Ingredient.pageCount, page + 1))}
                    >
                        <KeyboardArrowRightIcon />
                    </Button>
                    <Button variant="contained" onClick={() => setPage(Ingredient.pageCount)}>
                        <KeyboardDoubleArrowRightIcon />
                    </Button>
                </div>
            </div>

            <Dialog open={openEdit} onClose={handleCloseEdit}>
                <DialogTitle>Редактировать ингредиент</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Имя"
                        fullWidth
                        value={newIngredient.name}
                        onChange={(e) =>
                            setNewIngredient({ ...newIngredient, name: e.target.value })
                        }
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        label="В наличии"
                        fullWidth
                        value={newIngredient.in_stock}
                        onChange={(e) =>
                            setNewIngredient({ ...newIngredient, in_stock: Number(e.target.value) })
                        }
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseEdit}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>

            <Dialog open={openDelete} onClose={handleCloseDelete}>
                <DialogTitle>Подтверждение удаления</DialogTitle>
                <DialogContent>
                    <p>Вы уверены, что хотите удалить этого сотрудника?</p>
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

export default IngredientDataGrid;
