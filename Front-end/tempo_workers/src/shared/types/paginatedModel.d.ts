declare module "PaginatedType";

type PaginatedType<Model> = {
    items: Model[];
    limit: number;    
    page: number;     
    pageCount: number;
    total: number;
};

export default PaginatedType;