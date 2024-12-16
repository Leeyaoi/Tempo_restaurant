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
import DishesType from "../../shared/types/dishes";
import PaginatedType from "../../shared/types/paginatedModel";
import { useGlobalStore } from "../../shared/state/globalStore";

interface Props {
  dishes: PaginatedType<DishesType>;
  limit: number;
  handleLimitChange: (event: SelectChangeEvent) => void;
  page: number;
  setPage: (value: number) => void;
  handleEdit: (id: string, data: Partial<DishesType>) => void;
  handleDelete: (id: string) => void;
}

const DishesDataGrid = ({
  dishes,
  limit,
  handleLimitChange,
  page,
  setPage,
  handleEdit,
  handleDelete,
}: Props) => {
  const { updateDishes, fetchCategory, Category } = useGlobalStore();
  const [openEdit, setOpenEdit] = useState(false);
  const [openDelete, setOpenDelete] = useState(false);
  const [newDishes, setNewDishes] = useState<DishesType>({} as DishesType);
  const [editId, setEditId] = useState<string | null>(null);
  const [deleteId, setDeleteId] = useState<string | null>(null);

  useEffect(() => { fetchCategory() },
    []
  )

  const handleOpenEditDialog = (id: string, data: DishesType) => {
    setEditId(id);
    setNewDishes(data);
    setOpenEdit(true);
  };

  const handleCloseEdit = () => {
    setOpenEdit(false);
    setEditId(null);
    setNewDishes({} as DishesType);
  };

  const handleSave = async () => {
    console.log(editId);
    if (editId) {
      await updateDishes(editId, newDishes);
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

  const columns: GridColDef<DishesType[][number]>[] = [
    {
      field: "name",
      headerName: "Имя",
      width: 180,
      editable: false,
    },
    {
      field: "approx_time",
      headerName: "Приблизительное время",
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
          rows={dishes ? dishes.items : []}
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
        <p id="total_data">Всего записей: {dishes ? dishes.total : 0}</p>
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
            {dishes ? dishes.page : 0} .. {dishes ? dishes.pageCount : 0}
          </p>
          <Button
            variant="contained"
            onClick={() => setPage(Math.min(dishes.pageCount, page + 1))}
          >
            <KeyboardArrowRightIcon />
          </Button>
          <Button variant="contained" onClick={() => setPage(dishes.pageCount)}>
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
            value={newDishes.name}
            onChange={(e) =>
              setNewDishes({ ...newDishes, name: e.target.value })
            }
          />
          <TextField
            autoFocus
            margin="dense"
            label="Приблизительное время"
            fullWidth
            value={newDishes.approx_time}
            onChange={(e) =>
              setNewDishes({ ...newDishes, approx_time: Number(e.target.value) })
            }
          />
          <TextField
            autoFocus
            margin="dense"
            label="Цена"
            fullWidth
            value={newDishes.price}
            onChange={(e) =>
              setNewDishes({ ...newDishes, price: e.target.value })
            }
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

export default DishesDataGrid;
