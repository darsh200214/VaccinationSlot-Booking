import { MenuItem } from './menu.model';

export const MENU: MenuItem[] = [
    {
        id: 1,
        label: 'Dashboards',
        icon: 'bx-home-circle',
        subItems: [
            {
                id: 2,
                label: 'Default',
                link: '/dashboard',
                parentId: 1
            },
            {
                id: 3,
                label: 'Saas',
                link: 'javascript: void(0);',
                parentId: 1
            },
            {
                id: 4,
                label: 'Crypto',
                link: 'javascript: void(0);',
                parentId: 1
            },
        ]
    },
    {
        id: 5,
        label: 'UI Elements',
        icon: 'bx-tone',
        isUiElement: true,
        subItems: [
            {
                id: 6,
                label: 'Alerts',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 7,
                label: 'Buttons',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 8,
                label: 'Cards',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 9,
                label: 'Carousel',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 10,
                label: 'Dropdowns',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 11,
                label: 'Grid',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 12,
                label: 'Images',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 13,
                label: 'Modals',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 14,
                label: 'Range Slider',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 15,
                label: 'Progress Bars',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 16,
                label: 'Sweet-Alert',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 17,
                label: 'Tabs & Accordions',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 18,
                label: 'Typography',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 19,
                label: 'Video',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 20,
                label: 'General',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 21,
                label: 'Colors',
                link: 'javascript: void(0);',
                parentId: 5
            },
            {
                id: 22,
                label: 'Image Cropper',
                link: 'javascript: void(0);',
                parentId: 5
            },
        ]
    },
    {
        id: 23,
        label: 'Apps',
        subItems: [
            {
                id: 24,
                label: 'Calendar',
                link: 'javascript: void(0);',
            },
            {
                id: 25,
                label: 'Chat',
                link: 'javascript: void(0);',
            },
            {
                id: 26,
                label: 'Email',
                subItems: [
                    {
                        id: 27,
                        label: 'Inbox',
                        link: 'javascript: void(0);',
                        parentId: 26
                    },
                    {
                        id: 28,
                        label: 'Read Email',
                        link: 'javascript: void(0);',
                        parentId: 26
                    }
                ]
            },
            {
                id: 29,
                label: 'Ecommerce',
                subItems: [
                    {
                        id: 30,
                        label: 'Products',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 31,
                        label: 'Product Detail',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 32,
                        label: 'Orders',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 33,
                        label: 'Customers',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 34,
                        label: 'Cart',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 35,
                        label: 'Checkout',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 36,
                        label: 'Shops',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                    {
                        id: 37,
                        label: 'Add Product',
                        link: 'javascript: void(0);',
                        parentId: 29
                    },
                ]
            },
            {
                id: 38,
                label: 'Crypto',
                icon: 'bx-bitcoin',
                subItems: [
                    {
                        id: 39,
                        label: 'Wallet',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 40,
                        label: 'Buy/Sell',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 41,
                        label: 'Exchange',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 42,
                        label: 'Lending',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 43,
                        label: 'Orders',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 44,
                        label: 'KYC Application',
                        link: 'javascript: void(0);',
                        parentId: 38
                    },
                    {
                        id: 45,
                        label: 'ICO Landing',
                        link: 'javascript: void(0);',
                        parentId: 38
                    }
                ]
            },
            {
                id: 46,
                label: 'Projects',
                subItems: [
                    {
                        id: 47,
                        label: 'Projects Grid',
                        link: 'javascript: void(0);',
                        parentId: 46
                    },
                    {
                        id: 48,
                        label: 'Projects List',
                        link: 'javascript: void(0);',
                        parentId: 46
                    },
                    {
                        id: 49,
                        label: 'Project Overview',
                        link: 'javascript: void(0);',
                        parentId: 46
                    },
                    {
                        id: 50,
                        label: 'Create New',
                        link: 'javascript: void(0);',
                        parentId: 46
                    }
                ]
            },
            {
                id: 51,
                label: 'Tasks',
                subItems: [
                    {
                        id: 52,
                        label: 'Task List',
                        link: 'javascript: void(0);',
                        parentId: 51
                    },
                    {
                        id: 53,
                        label: 'Kanban Board',
                        link: 'javascript: void(0);',
                        parentId: 51
                    },
                    {
                        id: 54,
                        label: 'Create Task',
                        link: 'javascript: void(0);',
                        parentId: 51
                    }
                ]
            },
            {
                id: 55,
                label: 'Contacts',
                icon: 'bxs-user-detail',
                subItems: [
                    {
                        id: 56,
                        label: 'User Grid',
                        link: 'javascript: void(0);',
                        parentId: 55
                    },
                    {
                        id: 57,
                        label: 'User List',
                        link: 'javascript: void(0);',
                        parentId: 55
                    },
                    {
                        id: 58,
                        label: 'Profile',
                        link: 'javascript: void(0);',
                        parentId: 55
                    }
                ]
            },
        ]
    },
    {
        id: 59,
        icon: 'bx-collection',
        label: 'Components',
        subItems: [
            {
                id: 60,
                label: 'Forms',
                subItems: [
                    {
                        id: 61,
                        label: 'Form Elements',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 62,
                        label: 'Form Validation',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 63,
                        label: 'Form Advanced',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 64,
                        label: 'Form Editors',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 65,
                        label: 'Form File Upload',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 66,
                        label: 'Form Repeater',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 67,
                        label: 'Form Wizard',
                        link: 'javascript: void(0);',
                        parentId: 60
                    },
                    {
                        id: 68,
                        label: 'Form Mask',
                        link: 'javascript: void(0);',
                        parentId: 60
                    }
                ]
            },
            {
                id: 69,
                label: 'Tables',
                subItems: [
                    {
                        id: 70,
                        label: 'Basic Tables',
                        link: 'javascript: void(0);',
                        parentId: 69
                    },
                    {
                        id: 71,
                        label: 'Advanced Table',
                        link: 'javascript: void(0);',
                        parentId: 69
                    }
                ]
            },
            {
                id: 72,
                label: 'Charts',
                subItems: [
                    {
                        id: 73,
                        label: 'Apex charts',
                        link: 'javascript: void(0);',
                        parentId: 72
                    },
                    {
                        id: 74,
                        label: 'Chartjs Chart',
                        link: 'javascript: void(0);',
                        parentId: 72
                    },
                    {
                        id: 75,
                        label: 'Chartist Chart',
                        link: 'javascript: void(0);',
                        parentId: 72
                    },
                    {
                        id: 76,
                        label: 'E - Chart',
                        link: 'javascript: void(0);',
                        parentId: 72
                    }
                ]
            },
            {
                id: 77,
                label: 'Icons',
                subItems: [
                    {
                        id: 78,
                        label: 'Boxicons',
                        link: 'javascript: void(0);',
                        parentId: 77
                    },
                    {
                        id: 79,
                        label: 'Material Design',
                        link: 'javascript: void(0);',
                        parentId: 77
                    },
                    {
                        id: 80,
                        label: 'Dripicons',
                        link: 'javascript: void(0);',
                        parentId: 77
                    },
                    {
                        id: 81,
                        label: 'Font awesome',
                        link: 'javascript: void(0);',
                        parentId: 77
                    },
                ]
            },
            {
                id: 82,
                label: 'Maps',
                subItems: [
                    {
                        id: 83,
                        label: 'Google Maps',
                        link: 'javascript: void(0);',
                        parentId: 82
                    }
                ]
            }
        ]
    },
    {
        id: 84,
        label: 'Extra Pages',
        icon: 'bx-file',
        subItems: [
            {
                id: 85,
                label: 'Invoices',
                subItems: [
                    {
                        id: 86,
                        label: 'Invoice List',
                        link: 'javascript: void(0);',
                        parentId: 85
                    },
                    {
                        id: 87,
                        label: 'Invoice Detail',
                        link: 'javascript: void(0);',
                        parentId: 85
                    },
                ]
            },
            {
                id: 88,
                label: 'Authentication',
                subItems: [
                    {
                        id: 89,
                        label: 'Login',
                        link: 'javascript: void(0);',
                        parentId: 88
                    },
                    {
                        id: 90,
                        label: 'Register',
                        link: 'javascript: void(0);',
                        parentId: 88
                    },
                    {
                        id: 91,
                        label: 'Recover Password',
                        link: 'javascript: void(0);',
                        parentId: 88
                    },
                    {
                        id: 92,
                        label: 'Lock Screen',
                        link: 'javascript: void(0);',
                        parentId: 88
                    }
                ]
            },
            {
                id: 93,
                label: 'Utility',
                icon: 'bx-file',
                subItems: [
                    {
                        id: 94,
                        label: 'Starter Page',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 95,
                        label: 'Maintenance',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 96,
                        label: 'Timeline',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 97,
                        label: 'FAQs',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 98,
                        label: 'Pricing',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 99,
                        label: 'Error 404',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                    {
                        id: 100,
                        label: 'Error 500',
                        link: 'javascript: void(0);',
                        parentId: 93
                    },
                ]
            },
        ]
    }
];

