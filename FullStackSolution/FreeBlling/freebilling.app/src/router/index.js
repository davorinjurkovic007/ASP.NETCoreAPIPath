// router
import { createRouter, createWebHashHistory, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import BillingView from "../views/BillingView.vue";

const routes = [
  {
    name: "Home",
    path: "/",
    component: HomeView
  },
  {
    name: "Billing",
    path: "/billing",
    component: BillingView
  },
];

const router = createRouter({
  routes,
  history: createWebHistory()
});

export default router;
