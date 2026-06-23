// router
import { createRouter, createWebHashHistory, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import BillingView from "../views/BillingView.vue";
import LoginView from "../views/LoginView.vue"

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
  {
    name: "Login",
    path: "/login",
    component: LoginView
  },
];

const router = createRouter({
  routes,
  history: createWebHistory()
});

export default router;
